using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Notifications;
using Klinika.Requests.Services;
using Klinika.Requests.Models;
using Klinika.Core.Dependencies;
using Klinika.Core.Database;
using Klinika.Core.Utilities;

namespace Klinika.GUI.Secretary
{
    public partial class VacationDaysRequests : Form
    {
        private readonly NotificationService? notificationService;
        private VacationRequestService? vacationService;
        public VacationDaysRequests()
        {
            InitializeComponent();
            notificationService = StartUp.serviceProvider.GetService<NotificationService>();
            vacationService = StartUp.serviceProvider.GetService<VacationRequestService>();
        }

        private void VacationDaysRequests_Load(object sender, EventArgs e) => vacationRequestsTable.Fill(vacationService.GetAll());

        private void VacationRequestsTable_CellClick(object sender, DataGridViewCellEventArgs e) => SetButtonStates();

        private void SetButtonStates()
        { 

            VacationRequest selected = vacationRequestsTable.GetSelected();
            if (selected.status != 'W') 
            {
                approveButton.Enabled = false;
                denyButton.Enabled = false;
                return;
            }
            approveButton.Enabled = true;
            denyButton.Enabled = true;
        }

        private void ApproveButton_Click(object sender, EventArgs e) => Approve();

        private void DenyButton_Click(object sender, EventArgs e) => Deny();

        private void Approve()
        {
            bool approveConfirmation = UIUtilities.Confirm("Are you sure you want to approve the selected request?");
            if (!approveConfirmation) return;
            VacationRequest selected = vacationRequestsTable.GetSelected();
            selected.status = 'A';
            try
            {
                vacationService.Approve(selected);
                NotifyDoctor(selected);                
                vacationRequestsTable.ModifySelected(selected);
                MessageBoxUtilities.ShowSuccessMessage("Request successfully approved!");
                SetButtonStates();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void Deny()
        {
            bool denyConfirmation = UIUtilities.Confirm("Are you sure you want to deny the selected request?");
            if (!denyConfirmation) return;
            VacationRequest selected = vacationRequestsTable.GetSelected();
            selected.status = 'D';
            new VacationRequestDenialReason(selected).ShowDialog();
            try
            {
                vacationService.Deny(selected);
                NotifyDoctor(selected);
                vacationRequestsTable.ModifySelected(selected);
                MessageBoxUtilities.ShowSuccessMessage("Request successfully denied!");
                SetButtonStates();
            }
            catch (DatabaseConnectionException error)
            {
                MessageBoxUtilities.ShowErrorMessage(error.Message);
            }
        }

        private void NotifyDoctor(VacationRequest selected)
        {
            Notification notification = new Notification(selected.doctorID, NotificationService.GenerateMessage(selected));
            notificationService.Send(notification);
        }
    }
}

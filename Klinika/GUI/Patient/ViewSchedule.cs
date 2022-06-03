using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Utilities;
using Klinika.Models;
using Klinika.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Patient
{
    public partial class ViewSchedule : Form
    {
        internal Main parent;
        public ViewSchedule(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            InitPersonalAppointmentsTab();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void InitPersonalAppointmentsTab()
        {
            PersonalAppointmentsTable.Fill(AppointmentRepository.GetAll(parent.patient.id, User.RoleType.PATIENT));
            ModifyButton.Enabled = false;
            DeleteButton.Enabled = false;
        }
        private void ModifyButtonClick(object sender, EventArgs e)
        {
            new PersonalAppointment(this, PersonalAppointmentsTable.GetSelected()).Show();
        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to delete selected appointment?")) return;

            Appointment selected = PersonalAppointmentsTable.GetSelected();
            bool needApproval = DateTime.Now.AddDays(2).Date >= selected.dateTime.Date;

            if (needApproval && !UIUtilities.Confirm("Changes that you have requested have to be check by secretary. Do you want to send request?")) return;

            PatientRequestService.Send(!needApproval, selected, PatientRequest.Types.Delete);
            if (needApproval) return;

            AppointmentService.Delete(selected.id);
            PersonalAppointmentsTable.DeleteSelected();
        }
        private void PersonalAppointmentsTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            ModifyButton.Enabled = true;
            DeleteButton.Enabled = true;
        }
    }
}

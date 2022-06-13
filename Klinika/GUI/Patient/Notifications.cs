using Klinika.Core.Dependencies;
using Klinika.Core.Utilities;
using Klinika.Notifications;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Patient
{
    public partial class Notifications : Form
    {
        internal readonly Main parent;
        private readonly NotificationService? notificationService;
        private readonly PatientService? patientService;
        public Notifications(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
            notificationService = StartUp.serviceProvider.GetService<NotificationService>();
            patientService = StartUp.serviceProvider.GetService<PatientService>();
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            Initialize();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => parent.Enabled = true;
        private void Initialize()
        {
            OffsetNumericUpDown.Value = parent.patient.notificationOffset;
            SetButton.Enabled = false;
            NotificationsTable.Fill(notificationService.GetAll(parent.patient));
        }
        private void SetButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to save changes?")) return;
            parent.patient.notificationOffset = Convert.ToInt32(OffsetNumericUpDown.Value);
            patientService.Modify(parent.patient);
            NotificationsTable.Fill(notificationService.GetAll(parent.patient));
            SetButton.Enabled = false;
        }
        private void MarkAsReadButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want mark as read this notification?")) return;
            int selected = NotificationsTable.GetSelectedID();
            notificationService.MarkAsRead(selected);
            NotificationsTable.Rows.RemoveAt(NotificationsTable.CurrentRow.Index);
            MarkAsReadButton.Enabled = false;
        }
        private void NotificationsTableCellClick(object sender, DataGridViewCellEventArgs e) => MarkAsReadButton.Enabled = true;
        private void OffsetNumericUpDownValueChanged(object sender, EventArgs e) => SetButton.Enabled = true;
    }
}

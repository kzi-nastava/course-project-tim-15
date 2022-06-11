using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Patient
{
    public partial class Notifications : Form
    {
        internal readonly Main parent;
        public Notifications(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            Initialize();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void Initialize()
        {
            OffsetNumericUpDown.Value = parent.patient.notificationOffset;
            SetButton.Enabled = false;
            NotificationsTable.Fill(NotificationService.GetAll(parent.patient));
        }
        private void SetButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to save changes?")) return;
            parent.patient.notificationOffset = Convert.ToInt32(OffsetNumericUpDown.Value);
            PatientService.Modify(parent.patient);
            NotificationsTable.Fill(NotificationService.GetAll(parent.patient));
            SetButton.Enabled = false;
        }
        private void MarkAsReadButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want mark as read this notification?")) return;
            int selected = NotificationsTable.GetSelectedID();
            NotificationService.MarkAsRead(selected);
            NotificationsTable.Rows.RemoveAt(NotificationsTable.CurrentRow.Index);
            MarkAsReadButton.Enabled = false;
        }
        private void NotificationsTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            MarkAsReadButton.Enabled = true;
        }
        private void OffsetNumericUpDownValueChanged(object sender, EventArgs e)
        {
            SetButton.Enabled = true;
        }
    }
}

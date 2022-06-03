using System.Data;
using Klinika.Models;
using Klinika.Utilities;
using Klinika.Services;

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
            InitNotificationsTab();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void InitNotificationsTab()
        {
            OffsetNumericUpDown.Value = parent.patient.notificationOffset;
            SetButton.Enabled = false;
            FillNotificationsTable(NotificationService.GetAllForPatient(parent.patient));
        }
        private void FillNotificationsTable(List<Notification> notifications)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("DateTime");
            dataTable.Columns.Add("Message");

            if (notifications == null) return;
            foreach (Notification notification in notifications)
            {
                DataRow newRow = dataTable.NewRow();

                newRow["ID"] = notification.id;
                newRow["DateTime"] = notification.dateTime;
                newRow["Message"] = notification.message;
                dataTable.Rows.Add(newRow);
            }
            NotificationsTable.DataSource = dataTable;
            NotificationsTable.ClearSelection();
            MarkAsReadButton.Enabled = false;
        }
        private void SetButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to save changes?")) return;
            parent.patient.notificationOffset = Convert.ToInt32(OffsetNumericUpDown.Value);
            PatientService.Modify(parent.patient);
            FillNotificationsTable(NotificationService.GetAllForPatient(parent.patient));
            SetButton.Enabled = false;
        }
        private void MarkAsReadButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want mark as read this notification?")) return;
            int notificationID = Convert.ToInt32(UIUtilities.GetCellValue(NotificationsTable, "ID"));
            NotificationService.MarkAsRead(notificationID);
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

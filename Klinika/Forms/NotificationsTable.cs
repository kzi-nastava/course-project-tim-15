using System.Data;
using Klinika.Models;

namespace Klinika.Forms
{
    internal class NotificationsTable : Base.TableBase
    {
        public void Fill(List<Notification> notifications)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("DateTime");
            dataTable.Columns.Add("Message");
            DataSource = dataTable;
            if (notifications == null) return;
            foreach (Notification notification in notifications) Insert(notification);
            ClearSelection();
        }
        private void Insert(Notification notification)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = notification.id;
            newRow["DateTime"] = notification.dateTime;
            newRow["Message"] = notification.message;
            dt.Rows.Add(newRow);
        }
        public int GetSelectedID()
        {
            return Convert.ToInt32(GetCellValue("ID"));
    }
    }
}

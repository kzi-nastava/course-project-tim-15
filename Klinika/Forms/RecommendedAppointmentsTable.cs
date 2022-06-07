using System.Data;
using Klinika.Models;
using Klinika.Services;

namespace Klinika.Forms
{
    internal class RecommendedAppointmentsTable : DataGridView
    {
        public void Fill(List<Appointment> appointments = null)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Doctor ID");
            dataTable.Columns.Add("Doctor");
            dataTable.Columns.Add("DateTime");
            DataSource = dataTable;
            if (appointments == null) return;
            foreach (Appointment appointment in appointments) Insert(appointment);
            ClearSelection();
        }
        private void Insert(Appointment appointment)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["Doctor ID"] = appointment.doctorID;
            newRow["Doctor"] = DoctorService.GetFullName(appointment.doctorID);
            newRow["DateTime"] = appointment.dateTime;
            dt.Rows.Add(newRow);
        }
        public int GetSelectedID()
        {
            return Convert.ToInt32(SelectedRows[0].Cells["Doctor ID"].Value);
        }
    }
}

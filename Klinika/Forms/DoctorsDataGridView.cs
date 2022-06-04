using Klinika.Roles;
using Klinika.Services;
using System.Data;

namespace Klinika.Forms
{
    internal class DoctorsDataGridView : DataGridView
    {
        public void Fill(List<Doctor> doctors)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Doctor ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Specialization");
            dataTable.Columns.Add("Grade");
            DataSource = dataTable;
            //if (doctors == null) return;
            foreach (Doctor doctor in doctors) Insert(doctor);
            ClearSelection();
        }
        private void Insert(Doctor doctor)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["Doctor ID"] = doctor.id;
            newRow["Name"] = doctor.name;
            newRow["Surname"] = doctor.surname;
            newRow["Specialization"] = doctor.specialization;
            newRow["Grade"] = string.Format("{0:0.00}", DoctorService.GetGrade(doctor.id));
            dt.Rows.Add(newRow);
        }
        public int GetSelectedID()
        {
            return Convert.ToInt32(SelectedRows[0].Cells["Doctor ID"].Value);
        }
    }
}

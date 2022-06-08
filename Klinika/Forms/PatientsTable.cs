using Klinika.Models;
using System.Data;
using Klinika.Roles;
using Klinika.Forms.Base;

namespace Klinika.Forms
{
    public class PatientsTable : TableBase<Patient>
    {
        public override void Fill(List<Patient> patients)
        {
            DataTable patientsTable = new DataTable();
            patientsTable.Columns.Add("ID");
            patientsTable.Columns.Add("JMBG");
            patientsTable.Columns.Add("Name");
            patientsTable.Columns.Add("Surname");
            patientsTable.Columns.Add("Birthdate");
            patientsTable.Columns.Add("Gender");
            patientsTable.Columns.Add("Email");
            patientsTable.Columns.Add("Blocked");
            patientsTable.Columns.Add("Blocked by");

            foreach (Patient patient in patients)
            {
                DataRow newRow = patientsTable.NewRow();
                newRow["ID"] = patient.id;
                newRow["JMBG"] = patient.jmbg;
                newRow["Name"] = patient.name;
                newRow["Surname"] = patient.surname;
                newRow["Birthdate"] = patient.birthdate;
                newRow["Gender"] = patient.gender;
                newRow["Email"] = patient.email;
                newRow["Blocked"] = patient.isBlocked;
                newRow["Blocked by"] = patient.whoBlocked;
                patientsTable.Rows.Add(newRow);
            }
            DataSource = patientsTable;
            ClearSelection();
        }

        public void ModifyRow(DataGridViewRow row, Patient patient)
        {
            row.Cells["JMBG"].Value = patient.jmbg;
            row.Cells["Name"].Value = patient.name;
            row.Cells["Surname"].Value = patient.surname;
            row.Cells["Birthdate"].Value = patient.birthdate.Date;
            row.Cells["Gender"].Value = patient.gender;
            row.Cells["Email"].Value = patient.email;
            row.Cells["Blocked"].Value = patient.isBlocked;
            row.Cells["BlockedBy"].Value = patient.whoBlocked;
        }

        public void AddRow(Patient newPatient)
        {
            DataGridViewRow newRow = (DataGridViewRow)CurrentRow.Clone();
            ModifyRow(newRow, newPatient);
            Rows.Add(newRow);
        }

        public DataGridViewRow GetSelectedRow()
        {
            return CurrentRow;
        }

        public void DeleteSelectedRow()
        {
            Rows.RemoveAt(CurrentRow.Index);
        }
    }
}

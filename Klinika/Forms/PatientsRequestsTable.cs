using Klinika.Models;
using System.Data;
using Klinika.Roles;

namespace Klinika.Forms
{
    public class PatientsRequestsTable : Base.ReadonlyTableBase<Patient>
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

        public void ModifyRow(Patient patient)
        {
            row["JMBG"] = patient.jmbg;
            row["Name"] = patient.name;
            row["Surname"] = patient.surname;
            row["Birthdate"] = patient.birthdate.Date;
            row["Gender"] = patient.gender;
            row["Email"] = patient.email;
            row["Blocked"] = patient.isBlocked;
            row["BlockedBy"] = patient.whoBlocked;
        }

        public void AddRow(Patient newPatient)
        {
            DataRow newRow = patients.NewRow();
            ModifyRow(ref newRow, newPatient);
            patients.Rows.Add(newRow);
            patients.AcceptChanges();
        }
    }
}

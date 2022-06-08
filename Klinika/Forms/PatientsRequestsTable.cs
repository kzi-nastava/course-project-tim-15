using Klinika.Models;
using System.Data;
using Klinika.Roles;
using Klinika.Forms.Base;

namespace Klinika.Forms
{
    public class PatientsRequestsTable : TableBase<PatientRequest>
    {
        public override void Fill(List<PatientRequest> requests)
        {
            DataTable requestsTable = new DataTable();
            requestsTable.Columns.Add("ID");
            requestsTable.Columns.Add("Patient ID");
            requestsTable.Columns.Add("Appointment ID");
            requestsTable.Columns.Add("Type");
            requestsTable.Columns.Add("Approved");

            foreach (PatientRequest request in requests)
            {
                DataRow newRow = requestsTable.NewRow();
                newRow["ID"] = request.id;
                newRow["Patient ID"] = request.patientID;
                newRow["Appointment ID"] = request.medicalActionID;
                if (request.type == 'M') newRow["Type"] = "Modify";
                else newRow["Type"] = "Delete";
                newRow["Approved"] = request.approved;
                requestsTable.Rows.Add(newRow);
            }
            DataSource = requestsTable;
            ClearSelection();
        }

        public void ModifyRow(DataGridViewRow row,PatientRequest request)
        {
            row.Cells["ID"].Value = request.id;
            row.Cells["Patient ID"].Value = request.patientID;
            row.Cells["Appointment ID"].Value = request.medicalActionID;
            if (request.type == 'M') row.Cells["Type"].Value = "Modify";
            else row.Cells["Type"].Value = "Delete";
            row.Cells["Approved"].Value = request.approved;
        }

        public DataGridViewRow GetSelectedRow()
        {
            return CurrentRow;
        }

    }
}

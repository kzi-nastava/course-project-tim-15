using Klinika.Models;
using Klinika.Roles;
using Klinika.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Forms
{
    public class VacationRequestsDataGridView : DataGridView
    {
        private List<VacationRequest> VacationRequests;
        public VacationRequestsDataGridView() : base()
        {
            VacationRequests = new List<VacationRequest>();
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public void Fill(List<VacationRequest> vacationRequests)
        {
            DataTable vacationRequestsData = new DataTable();
            vacationRequestsData.Columns.Add("ID");
            vacationRequestsData.Columns.Add("From Date");
            vacationRequestsData.Columns.Add("To Date");
            vacationRequestsData.Columns.Add("Reason");
            vacationRequestsData.Columns.Add("Status");
            vacationRequestsData.Columns.Add("Emergency");
            vacationRequestsData.Columns.Add("Deny Reason");

            DataSource = vacationRequestsData;
            Columns["ID"].Width = 45;
            Columns["Emergency"].Width = 55;

            VacationRequests = new List<VacationRequest>();
            foreach (VacationRequest vacationRequest in vacationRequests) Insert(vacationRequest);

            ClearSelection();
        }
        public void Insert(VacationRequest vacationRequest)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = vacationRequest.ID;
            newRow["From Date"] = vacationRequest.FromDate;
            newRow["To Date"] = vacationRequest.ToDate;
            newRow["Reason"] = vacationRequest.Reason;
            newRow["Status"] = vacationRequest.Status;
            newRow["Emergency"] = vacationRequest.Emergency;
            newRow["Deny Reason"] = vacationRequest.DenyReason;
            dt.Rows.Add(newRow);
            VacationRequests.Add(vacationRequest);
        }
        public List<VacationRequest> GetAll() { return VacationRequests; }
        public int GetSelectedID()
        {
            return Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
        }
        public VacationRequest GetSelected()
        {
            return VacationRequests.Where(x => x.ID == GetSelectedID()).First();
        }
        public int DeleteSelected()
        {
            var selected = GetSelectedID();
            Rows.RemoveAt(CurrentRow.Index);
            return selected;
        }
        public void ModifySelected(VacationRequest vacationRequest)
        {
            SelectedRows[0].SetValues(
                vacationRequest.ID.ToString(),
                vacationRequest.FromDate,
                vacationRequest.ToDate,
                vacationRequest.Reason,
                vacationRequest.Status,
                vacationRequest.Emergency,
                vacationRequest.DenyReason);

            VacationRequests.Remove(VacationRequests.Where(x => x.ID == vacationRequest.ID).FirstOrDefault());
            VacationRequests.Add(vacationRequest);
        }
    }
}

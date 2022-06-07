﻿using Klinika.Models;
using System.Data;

namespace Klinika.Forms
{
    public class VacationRequestsTable : Base.TableBase
    {
        private List<VacationRequest> vacationRequests;
        public VacationRequestsTable() : base()
        {
            vacationRequests = new List<VacationRequest>();
        }
        public void Fill(List<VacationRequest> vacationRequests)
        {
            DataTable vacationRequestsData = new DataTable();
            vacationRequestsData.Columns.Add("ID");
            vacationRequestsData.Columns.Add("From");
            vacationRequestsData.Columns.Add("To");
            vacationRequestsData.Columns.Add("Reason");
            vacationRequestsData.Columns.Add("Status");
            vacationRequestsData.Columns.Add("Urgent", typeof(bool));
            vacationRequestsData.Columns.Add("Deny Reason");

            DataSource = vacationRequestsData;
            Columns["ID"].Width = 45;
            Columns["From"].Width = 80;
            Columns["To"].Width = 80;
            Columns["Status"].Width = 70;
            Columns["Urgent"].Width = 65;

            this.vacationRequests = new List<VacationRequest>();
            foreach (VacationRequest vacationRequest in vacationRequests) Insert(vacationRequest);

            ClearSelection();
        }
        public void Insert(VacationRequest vacationRequest)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = vacationRequest.id;
            newRow["From"] = vacationRequest.fromDate.ToString("MM.dd.yyyy");
            newRow["To"] = vacationRequest.toDate.ToString("MM.dd.yyyy");
            newRow["Reason"] = vacationRequest.reason;
            newRow["Status"] = ((VacationRequest.Statuses)vacationRequest.status).ToString();
            newRow["Urgent"] = vacationRequest.emergency;
            newRow["Deny Reason"] = vacationRequest.denyReason;
            dt.Rows.Add(newRow);
            vacationRequests.Add(vacationRequest);
        }
        public List<VacationRequest> GetAll() { return vacationRequests; }
        public int GetSelectedID()
        {
            return Convert.ToInt32(GetCellValue("ID"));
        }
        public VacationRequest GetSelected()
        {
            return vacationRequests.Where(x => x.id == GetSelectedID()).First();
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
                vacationRequest.id.ToString(),
                vacationRequest.fromDate.ToString("MM.dd.yyyy"),
                vacationRequest.toDate.ToString("MM.dd.yyyy"),
                vacationRequest.reason,
                vacationRequest.status.ToString(),
                vacationRequest.emergency,
                vacationRequest.denyReason);

            vacationRequests.Remove(vacationRequests.Where(x => x.id == vacationRequest.id).FirstOrDefault());
            vacationRequests.Add(vacationRequest);
        }
    }
}

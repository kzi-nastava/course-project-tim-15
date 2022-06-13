using Klinika.Models;
using System.Data;
using Klinika.Services;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.Forms
{
    public class VacationRequestsTable : Base.TableBase<VacationRequest>
    {
        private List<VacationRequest> vacationRequests;
        private bool showDoctor = false;
        public VacationRequestsTable(bool showDoctor = false) : base()
        {
            vacationRequests = new List<VacationRequest>();
            this.showDoctor = showDoctor;
        }

        public override void Fill(List<VacationRequest> vacationRequests)
        {
            DataTable vacationRequestsData = new DataTable();
            vacationRequestsData.Columns.Add("ID");
            if (showDoctor) vacationRequestsData.Columns.Add("Doctor");
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
            if (showDoctor) Columns["Doctor"].Width = 130;

            this.vacationRequests = new List<VacationRequest>();
            foreach (VacationRequest vacationRequest in vacationRequests) Insert(vacationRequest);

            ClearSelection();
        }
        public void Insert(VacationRequest vacationRequest)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = vacationRequest.id;
            if (showDoctor) newRow["Doctor"] = StartUp.serviceProvider.GetService<DoctorService>().GetFullName(vacationRequest.doctorID);
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
            SelectedRows[0].Cells["ID"].Value = vacationRequest.id.ToString();
            if(showDoctor) SelectedRows[0].Cells["Doctor"].Value = StartUp.serviceProvider.GetService<DoctorService>().GetFullName(vacationRequest.doctorID);
            SelectedRows[0].Cells["From"].Value = vacationRequest.fromDate.ToString("MM.dd.yyyy");
            SelectedRows[0].Cells["To"].Value = vacationRequest.toDate.ToString("MM.dd.yyyy");
            SelectedRows[0].Cells["Reason"].Value = vacationRequest.reason;
            SelectedRows[0].Cells["Status"].Value = ((VacationRequest.Statuses)vacationRequest.status).ToString();
            SelectedRows[0].Cells["Urgent"].Value = vacationRequest.emergency;
            SelectedRows[0].Cells["Deny reason"].Value = vacationRequest.denyReason;

            vacationRequests.Remove(vacationRequests.Where(x => x.id == vacationRequest.id).FirstOrDefault());
            vacationRequests.Add(vacationRequest);
        }
    }
}

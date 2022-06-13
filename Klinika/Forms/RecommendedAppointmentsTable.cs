using Klinika.Appointments.Models;
using Klinika.Core.Dependencies;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Klinika.Forms
{
    internal class RecommendedAppointmentsTable : Base.TableBase<Appointment>
    {
        private readonly DoctorService? doctorService;
        public RecommendedAppointmentsTable() : base() => doctorService = StartUp.serviceProvider.GetService<DoctorService>();
        public override void Fill(List<Appointment> appointments = null)
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
            newRow["Doctor"] = doctorService.GetFullName(appointment.doctorID);
            newRow["DateTime"] = appointment.dateTime;
            dt.Rows.Add(newRow);
        }
        public int GetSelectedID()
        {
            return Convert.ToInt32(GetCellValue("Doctor ID"));
        }
    }
}

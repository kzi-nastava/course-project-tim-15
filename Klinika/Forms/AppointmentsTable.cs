using Klinika.Models;
using Klinika.Roles;
using Klinika.Services;
using System.Data;

namespace Klinika.Forms
{
    public class AppointmentsTable : Base.TableBase
    {
        private List<Appointment> appointments;
        private User.RoleType viewerRole;
        private string searchedRole;
        public AppointmentsTable() : base()
        {
            appointments = new List<Appointment>();
            SetViewerRole(User.RoleType.DOCTOR);
        }
        public AppointmentsTable(User.RoleType viewerRole) : base()
        {
            appointments = new List<Appointment>();
            SetViewerRole(viewerRole);
        }
        private void SetViewerRole(User.RoleType viewerRole)
        {
            this.viewerRole = viewerRole;
            searchedRole = viewerRole == User.RoleType.DOCTOR ? "Patient" : "Doctor";
        }
        public void Fill(List<Appointment> appointments)
        {
            DataTable appointmetnsData = new DataTable();
            appointmetnsData.Columns.Add("ID");
            appointmetnsData.Columns.Add($"{searchedRole} Full Name");
            appointmetnsData.Columns.Add("Date & Time");
            appointmetnsData.Columns.Add("Type");
            appointmetnsData.Columns.Add("Room");
            appointmetnsData.Columns.Add("Duration [min]");
            appointmetnsData.Columns.Add("Urgent", typeof(bool));
            appointmetnsData.Columns.Add("Completed", typeof(bool));

            DataSource = appointmetnsData;
            Columns["ID"].Width = 45;
            Columns["Date & Time"].Width = 155;
            Columns["Duration [min]"].Width = 80;
            Columns["Urgent"].Width = 80;
            Columns["Completed"].Width = 90;

            this.appointments = new List<Appointment>();
            foreach (Appointment appointment in appointments) Insert(appointment);

            ClearSelection();
        }
        public void Insert(Appointment appointment)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = appointment.id;
            newRow[$"{searchedRole} Full Name"] = GetFullName(appointment);
            newRow["Date & Time"] = appointment.dateTime;
            newRow["Type"] = appointment.GetFullType();
            newRow["Room"] = RoomServices.GetSingle(appointment.roomID).ToString();
            newRow["Duration [min]"] = appointment.duration;
            newRow["Urgent"] = appointment.urgent;
            newRow["Completed"] = appointment.completed;
            dt.Rows.Add(newRow);
            appointments.Add(appointment);
        }
        public int GetSelectedID()
        {
            return Convert.ToInt32(GetCellValue("ID"));
        }
        public Appointment GetSelected()
        {
            return appointments.Where(x => x.id == GetSelectedID()).First();
        }
        public int DeleteSelected()
        {
            var selected = GetSelectedID();
            Rows.RemoveAt(CurrentRow.Index);
            return selected;
        }
        public void ModifySelected(Appointment appointment)
        {
            SelectedRows[0].SetValues(appointment.id.ToString(),
                GetFullName(appointment),
                appointment.dateTime.ToString(),
                appointment.GetFullType(),
                RoomServices.GetSingle(appointment.roomID).ToString(),
                appointment.duration.ToString(),
                appointment.urgent,
                appointment.completed);

            appointments.Remove(appointments.Where(x => x.id == appointment.id).FirstOrDefault());
            appointments.Add(appointment);
        }
        private string GetFullName(Appointment appointment)
        {
            if (viewerRole == User.RoleType.DOCTOR)
            {
                return PatientService.GetFullName(appointment.patientID);
            }
            return DoctorService.GetFullName(appointment.doctorID);
        }
    }
}

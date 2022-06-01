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
    public class AppointmentsDataGridView : DataGridView
    {
        private List<Appointment> Appointments;
        private User.RoleType ViewerRole;
        private string SearchedRole;
        public AppointmentsDataGridView(User.RoleType viewerRole) : base()
        {
            Appointments = new List<Appointment>();
            SetViewerRole(viewerRole);
        }
        private void SetViewerRole(User.RoleType viewerRole)
        {
            ViewerRole = viewerRole;
            SearchedRole = viewerRole == User.RoleType.DOCTOR ? "Patient" : "Doctor";
        }
        public void Fill(List<Appointment> appointments)
        {
            DataTable appointmetnsData = new DataTable();
            appointmetnsData.Columns.Add("ID");
            appointmetnsData.Columns.Add($"{SearchedRole} Full Name");
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

            Appointments = new List<Appointment>();
            foreach (Appointment appointment in appointments) Insert(appointment);

            ClearSelection();
        }
        public void Insert(Appointment appointment)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = appointment.id;
            newRow[$"{SearchedRole} Full Name"] = GetFullName(appointment);
            newRow["Date & Time"] = appointment.dateTime;
            newRow["Type"] = appointment.GetFullType();
            newRow["Room"] = RoomServices.GetSingle(appointment.roomID).ToString();
            newRow["Duration [min]"] = appointment.duration;
            newRow["Urgent"] = appointment.urgent;
            newRow["Completed"] = appointment.completed;
            dt.Rows.Add(newRow);
            Appointments.Add(appointment);
        }
        public int GetSelectedID()
        {
            return Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
        }
        public Appointment GetSelected()
        {
            return Appointments.Where(x => x.id == GetSelectedID()).First();
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

            Appointments.Remove(Appointments.Where(x => x.id == appointment.id).FirstOrDefault());
            Appointments.Add(appointment);
        }
        private string GetFullName(Appointment appointment)
        {
            if (ViewerRole == User.RoleType.DOCTOR)
            {
                return PatientService.GetFullName(appointment.patientID);
            }
            return DoctorService.GetFullName(appointment.doctorID);
        }
    }
}

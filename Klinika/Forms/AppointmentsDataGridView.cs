using Klinika.Models;
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
        public AppointmentsDataGridView() : base()
        {
            Appointments = new List<Appointment>();
        }
        public void Fill(List<Appointment> appointments)
        {
            Appointments = appointments;

            DataTable appointmetnsData = new DataTable();
            appointmetnsData.Columns.Add("ID");
            appointmetnsData.Columns.Add("Patient Full Name");
            appointmetnsData.Columns.Add("Date & Time");
            appointmetnsData.Columns.Add("Type");
            appointmetnsData.Columns.Add("Duration [min]");
            appointmetnsData.Columns.Add("Urgent", typeof(bool));
            appointmetnsData.Columns.Add("Completed", typeof(bool));

            DataSource = appointmetnsData;
            Columns[0].Width = 45;

            foreach (Appointment appointment in Appointments) Insert(appointment);

            ClearSelection();
        }

        public void Insert(Appointment appointment)
        {
            DataTable? dt = DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["ID"] = appointment.ID;
            newRow["Patient Full Name"] = PatientService.GetFullName(appointment.PatientID);
            newRow["Date & Time"] = appointment.DateTime;
            newRow["Type"] = appointment.GetType();
            newRow["Duration [min]"] = appointment.Duration;
            newRow["Urgent"] = appointment.Urgent;
            newRow["Completed"] = appointment.Completed;
            dt.Rows.Add(newRow);
        }
        public int GetSelectedID()
        {
            return Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
        }
        public Appointment GetSelected()
        {
            return Appointments.Where(x => x.ID == GetSelectedID()).First();
        }
        public int DeleteSelected()
        {
            var selected = GetSelectedID();
            Rows.RemoveAt(CurrentRow.Index);
            return selected;
        }
        public void UpdateSelected(Appointment appointment)
        {
            SelectedRows[0].SetValues(appointment.ID.ToString(),
                PatientService.GetFullName(appointment.PatientID),
                appointment.DateTime.ToString(),
                appointment.GetType(),
                appointment.Duration.ToString(),
                appointment.Urgent,
                appointment.Completed);
        }
    }
}

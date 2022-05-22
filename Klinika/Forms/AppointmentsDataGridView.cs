﻿using Klinika.Models;
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
            Appointments = appointments;

            DataTable appointmetnsData = new DataTable();
            appointmetnsData.Columns.Add("ID");
            appointmetnsData.Columns.Add($"{SearchedRole} Full Name");
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
            newRow[$"{SearchedRole} Full Name"] = GetFullName(appointment);
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
        public void ModifySelected(Appointment appointment)
        {
            SelectedRows[0].SetValues(appointment.ID.ToString(),
                GetFullName(appointment),
                appointment.DateTime.ToString(),
                appointment.GetType(),
                appointment.Duration.ToString(),
                appointment.Urgent,
                appointment.Completed);
        }
        private string GetFullName(Appointment appointment)
        {
            if (ViewerRole == User.RoleType.DOCTOR)
            {
                return PatientService.GetFullName(appointment.PatientID);
            }
            return DoctorService.GetFullName(appointment.DoctorID);
        }
    }
}

﻿using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System.Data;

namespace Klinika.GUI.Patient
{
    public partial class PersonalAppointment : Form
    {
        private readonly PatientMain Parent;
        private Appointment? Appointment;
        public PersonalAppointment(PatientMain parent, Appointment appointment)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
        }

        #region Loads and closing
        private void PersonalAppointmentLoad(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            Parent.FillDoctorComboBox(DoctorComboBox);
            DatePicker.MinDate = DateTime.Now;
            SetAppointmentDetails();
        }
        private void PersonalAppointmentClosing(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        #region Click functions
        private void ConfirmeButtonClick(object sender, EventArgs e)
        {
            if (Appointment == null)
            {
                if (!AppointmentRepository.GetInstance().IsOccupied(MergeDate()))
                {
                    CreateAppointment();
                    Close();
                }
                else
                {
                    MessageBox.Show("This time is occupied!", "Denied Create", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (!AppointmentRepository.GetInstance().IsOccupied(MergeDate(), 15, Appointment.ID))
                {
                    ModifyAppointment();
                    Close();
                }
                else
                {
                    MessageBox.Show("This time is occupied!", "Denied Modify", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion

        #region Helper functions
        private void SetAppointmentDetails()
        {
            if (Appointment == null)
            {
                DatePicker.Enabled = false;
                DatePicker.Value = Parent.AppointmentDatePicker.Value;
                DoctorComboBox.Enabled = false;
                DoctorComboBox.SelectedIndex = Parent.DoctorComboBox.SelectedIndex;
            }
            else
            {
                DatePicker.Enabled = true;
                DatePicker.Value = Appointment.DateTime.Date;
                TimePicker.Enabled = true;
                TimePicker.Value = Appointment.DateTime;
                DoctorComboBox.Enabled = true;
                DoctorComboBox.SelectedIndex = DoctorComboBox.Items.IndexOf(UserRepository.GetInstance().Users.Where(x => x.ID == Appointment.DoctorID).FirstOrDefault());
            }
        }
        private void CreateAppointment()
        {
            Appointment = new Appointment();
            Appointment.ID = -1;
            Appointment.DoctorID = GetDoctorID();
            Appointment.PatientID = Parent.Patient.ID;
            Appointment.DateTime = MergeDate();
            Appointment.RoomID = 1;
            Appointment.Completed = false;
            Appointment.Type = 'E';
            Appointment.Duration = 15;
            Appointment.Urgent = false;
            Appointment.Description = "";
            Appointment.IsDeleted = false;
            AppointmentRepository.GetInstance().Create(Appointment);
            Parent.InsertRowIntoPersonalAppointmentsTable(Appointment);
            Parent.InsertRowIntoOccupiedTable(Appointment);
            Parent.Enabled = true;
        }
        private void ModifyAppointment()
        {
            Appointment.DoctorID = GetDoctorID();
            Appointment.DateTime = MergeDate();
            AppointmentRepository.GetInstance().Modify(Appointment);
            Parent.ModifyPersonalAppointmentTableRow(Appointment);
            Parent.Enabled = true;
        }
        private int GetDoctorID()
        {
            return (DoctorComboBox.SelectedItem as User).ID;
        }
        private DateTime MergeDate()
        {
            var selectedDate = DatePicker.Value;
            var selectedTime = TimePicker.Value;
            var dateTime = DateTime.Parse($"{selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day} {selectedTime.Hour}:{selectedTime.Minute}");
            return dateTime;
        }
        #endregion
    }
}

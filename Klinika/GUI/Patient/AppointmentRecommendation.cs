﻿using Microsoft.Extensions.DependencyInjection;
using Klinika.Users.Models;
using Klinika.Appointments.Models;
using Klinika.Appointments.Services;
using Klinika.Core.Dependencies;
using Klinika.Core.Utilities;
using Klinika.Schedule.Models;

namespace Klinika.GUI.Patient
{
    public partial class AppointmentRecommendation : Form
    {
        private readonly AppointmentRecommendationService? recommendationService;
        private readonly AppointmentService? appointmentService;
        private readonly NewAppointment parent;

        #region Form
        public AppointmentRecommendation(NewAppointment parent)
        {
            InitializeComponent();
            recommendationService = StartUp.serviceProvider.GetService<AppointmentRecommendationService>();
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            UIUtilities.FillDoctorComboBox(DoctorComboBox);
            RecommendedAppointmentTable.Fill();
            parent.Enabled = false;
            ScheduleButton.Enabled = false;
            DoctorRadioButton.Checked = true;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => parent.Enabled = true;
        private void CancelClick(object sender, EventArgs e) => Close();
        #endregion

        private void RecommendButtonClick(object sender, EventArgs e)
        {
            if (!IsDateValid())
            {
                MessageBoxUtilities.ShowErrorMessage("Time is not valid! Please enter valid time.");
                return;
            }
            ShowRecommended();
        }
        private void ScheduleButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to create this Appoinment?")) return;
            Create();
            Close();
        }

        private void ShowRecommended()
        {
            int doctorID = (DoctorComboBox.SelectedItem as User).id;
            char priority = DoctorRadioButton.Checked ? 'D' : 'T';
            TimeSlot timeSlot = new TimeSlot(FromTimePicker.Value, ToTimePicker.Value);

            List<Appointment> recommended = recommendationService.Find(doctorID, timeSlot, DeadlineDatePicker.Value, priority);
            RecommendedAppointmentTable.Fill(recommended);
        }
        private void RecommendedAppointmentTableRowSelected(object sender, DataGridViewCellEventArgs e) => ScheduleButton.Enabled = true;
        private DateTime GetSelectedDateTime()
        {
            return Convert.ToDateTime(RecommendedAppointmentTable.SelectedRows[0].Cells["DateTime"].Value);
        }
        private bool IsDateValid()
        {
            return FromTimePicker.Value < ToTimePicker.Value && DeadlineDatePicker.Value > DateTime.Now;
        }
        private void Create()
        {
            Appointment appointment = new Appointment(RecommendedAppointmentTable.GetSelectedID(), parent.patient.id, GetSelectedDateTime());
            appointmentService.Create(appointment);
        }
    }
}
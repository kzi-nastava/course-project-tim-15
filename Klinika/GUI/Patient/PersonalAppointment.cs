﻿using Klinika.Dependencies;
using Klinika.Models;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Patient
{
    public partial class PersonalAppointment : Form
    {
        private readonly DoctorScheduleService? scheduleService;
        private readonly AppointmentService? appointmentService;
        private readonly DoctorService? doctorService;
        private readonly PatientRequestService? patientRequestService;
        private readonly UserService? userService;
        private readonly PersonalAppointmentDTO dto;
        #region Form
        public PersonalAppointment(PersonalAppointmentDTO dto)
        {
            InitializeComponent();
            scheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
            doctorService = StartUp.serviceProvider.GetService<DoctorService>();
            patientRequestService = StartUp.serviceProvider.GetService<PatientRequestService>();
            userService = StartUp.serviceProvider.GetService<UserService>();
            this.dto = dto;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            dto.DisabledParent();
            UIUtilities.FillDoctorComboBox(DoctorComboBox);
            FillFormDetails();
        }
        private void FillFormDetails()
        {
            if (dto.isCreate) SetupAsCreate();
            else SetupAsModify();
        }
        private void SetupAsCreate()
        {
            DoctorComboBox.Enabled = false;
            SetDoctorComboBoxIndex();
            if (!dto.isDatePicked) return;
            DatePicker.Enabled = false;
            DatePicker.Value = dto.appointment.dateTime;
        }
        private void SetupAsModify()
        {
            DatePicker.Enabled = true;
            DatePicker.Value = dto.appointment.dateTime.Date;
            TimePicker.Enabled = true;
            TimePicker.Value = dto.appointment.dateTime;
            DoctorComboBox.Enabled = true;
            SetDoctorComboBoxIndex();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => dto.EnableParent();
        #endregion

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (dto.isCreate) Create();
            else Modify();
        }
        private void Create()
        {
            if (!UIUtilities.Confirm("Are you sure you want to create this Appoinment ?")) return;

            dto.appointment.dateTime = GetSelectedDateTime();
            appointmentService.Create(dto.appointment);

            if (dto.isDatePicked) dto.InsertNewAppointmentInTable();

            Close();
        }
        private void Modify()
        {
            if (!UIUtilities.Confirm("Are you sure you want to save the changes?")) return;

            dto.appointment.doctorID = GetSelectedDoctorID();
            dto.appointment.dateTime = GetSelectedDateTime();
            dto.appointment.roomID = doctorService.GetById(dto.appointment.doctorID).officeID;

            bool needApproval = DateTime.Now.AddDays(2).Date >= dto.appointment.dateTime.Date;
            if (needApproval && !UIUtilities.Confirm("Changes that you have requested have to be check by secretary. Do you want to send request?")) return;

            patientRequestService.Send(!needApproval, dto.appointment, PatientRequest.Types.MODIFY);
            if (!needApproval)
            {
                appointmentService.Modify(dto.appointment);
                dto.ModifyAppointmentInTable();
            }
            Close();
        }  
        private int GetSelectedDoctorID() => (DoctorComboBox.SelectedItem as User).id;
        private DateTime GetSelectedDateTime()
        {
            var selectedDate = DatePicker.Value;
            var selectedTime = TimePicker.Value;
            var dateTime = DateTime.Parse($"{selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day} {selectedTime.Hour}:{selectedTime.Minute}");
            return dateTime;
        }
        private void SetDoctorComboBoxIndex()
        {
            User selected = userService.GetDoctor(dto.appointment.doctorID);
            DoctorComboBox.SelectedIndex = DoctorComboBox.Items.IndexOf(selected);
        }
        private bool ValidateForm()
        {
            if (!IsDateValid(GetSelectedDateTime())) return false;
            if (!scheduleService.IsOccupied(GetSelectedDateTime(), GetSelectedDoctorID())) return true;
            MessageBoxUtilities.ShowErrorMessage("This time is occupied!");
            return false;
        }
        public bool IsDateValid(DateTime dateTime)
        {
            if (dateTime > DateTime.Now) return true;
            MessageBoxUtilities.ShowErrorMessage("Date is not valid!");
            return false;
        }
    }
}
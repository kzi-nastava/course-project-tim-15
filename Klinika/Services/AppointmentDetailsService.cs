using Klinika.GUI.Doctor;
using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    public class AppointmentDetailsService
    {
        private readonly AppointmentDetails Form;
        public AppointmentDetailsService(AppointmentDetails form)
        {
            Form = form;
        }
        public bool Validate(DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
            {
                MessageBox.Show("Please select valid date!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Form.PatientComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select patient!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (AppointmentRepository.GetInstance().IsOccupied(dateTime, Form.Parent.Doctor.ID, Convert.ToInt32(Form.DurationTextBox.Text)))
            {
                MessageBox.Show("Already occupied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void FinishForm(Appointment? appointment)
        {
            var selectedDate = Form.DatePicker.Value;
            var selectedTime = Form.TimePicker.Value;
            var selectedDateTime = DateTime.Parse($"{selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day} {selectedTime.Hour}:{selectedTime.Minute}");

            if (!Validate(selectedDateTime)) return;

            if (appointment != null)
            {
                appointment.DateTime = selectedDateTime;
                ModifyInDatabase(appointment);
                return;
            }
            CreateInDatabase(new Appointment(selectedDateTime));
        }
        private void CreateInDatabase(Appointment appointment)
        {
            TransferDataFromUI(appointment);
            AppointmentRepository.GetInstance().Create(appointment);
            Form.Parent.InsertIntoAllAppointmentsTable(appointment);
        }
        private void ModifyInDatabase(Appointment appointment)
        {
            TransferDataFromUI(appointment);
            AppointmentRepository.GetInstance().Modify(appointment);
            DoctorService.UpdateTableRow(appointment, Form.Parent.AllAppointmentsTable);
        }
        private void TransferDataFromUI(Appointment appointment)
        {
            appointment.DoctorID = Form.Parent.Doctor.ID;
            appointment.PatientID = (Form.PatientComboBox.SelectedItem as User).ID;
            appointment.Type = Form.ExaminationRadioButton.Checked ? 'E' : 'O';
            appointment.Duration = Convert.ToInt32(Form.DurationTextBox.Text);
            appointment.Urgent = Form.IsUrgentCheckBox.Checked;
            appointment.Description = "";
        }
    }
}

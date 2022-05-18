using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Doctor
{
    public partial class AppointmentDetails : Form
    {
        internal readonly DoctorMain Parent;
        private Appointment? Appointment;

        public AppointmentDetails(DoctorMain parent, Appointment appointment = null)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            PatientComboBox.Items.AddRange(UserRepository.GetPatients());

            if (Appointment == null)
            {
                SetTypeExamination();
                return;
            }

            FillFormWithAppointmentData();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }

        private void FillFormWithAppointmentData()
        {
            DatePicker.Value = Appointment.DateTime;
            TimePicker.Value = Appointment.DateTime;
            PatientComboBox.SelectedIndex = PatientComboBox.Items.IndexOf(UserRepository.GetInstance().Users.Where(x => x.ID == Appointment.PatientID).FirstOrDefault());

            if (Appointment.Type == 'E') SetTypeExamination();
            else SetTypeOperation(Appointment.Duration);

            IsUrgentCheckBox.Checked = Appointment.Urgent;
            ConfirmButton.Text = "Save";
        }
        private void SetTypeExamination()
        {
            ExaminationRadioButton.Checked = true;
            OperationRadioButton.Checked = false;
            DurationTextBox.Enabled = false;
            DurationTextBox.Text = "15";
        }
        private void SetTypeOperation(int duration = -1)
        {
            ExaminationRadioButton.Checked = false;
            OperationRadioButton.Checked = true;
            DurationTextBox.Enabled = true;
            DurationTextBox.Text = duration == -1 ? "" : duration.ToString();
        }
        private void ExaminationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if(ExaminationRadioButton.Checked)
            {
                SetTypeExamination();
                return;
            }
            SetTypeOperation();
        }
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (Appointment != null) Modify();
            else Create();

            Close();
        }

        private bool ValidateForm()
        {
            if (!IsDateValid())
            {
                MessageBox.Show("Please select valid date!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (PatientComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select patient!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (AppointmentRepository.GetInstance().IsOccupied(GetSelectedDateTime(), Parent.Doctor.ID, Convert.ToInt32(DurationTextBox.Text)))
            {
                MessageBox.Show("Already occupied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool IsDateValid()
        {
            if (GetSelectedDateTime() < DateTime.Now) return false;
            return true;
        }
        private DateTime GetSelectedDateTime()
        {
            var selectedDate = DatePicker.Value;
            var selectedTime = TimePicker.Value;
            return DateTime.Parse($"{selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day} {selectedTime.Hour}:{selectedTime.Minute}");
        }
        private void TransferDataFromUI(Appointment appointment)
        {
            appointment.DoctorID = Parent.Doctor.ID;
            appointment.PatientID = (PatientComboBox.SelectedItem as User).ID;
            appointment.Type = ExaminationRadioButton.Checked ? 'E' : 'O';
            appointment.Duration = Convert.ToInt32(DurationTextBox.Text);
            appointment.Urgent = IsUrgentCheckBox.Checked;
            appointment.Description = "";
        }
        private void Modify()
        {
            Appointment.DateTime = GetSelectedDateTime();
            TransferDataFromUI(Appointment);
            AppointmentService.Modify(Appointment);
            DoctorService.UpdateTableRow(Appointment, Parent.AllAppointmentsTable);
        }
        private void Create()
        {
            var appointment = new Appointment(GetSelectedDateTime());
            TransferDataFromUI(appointment);
            AppointmentService.Create(appointment);
            Parent.InsertIntoAllAppointmentsTable(appointment);
        }
    }
}

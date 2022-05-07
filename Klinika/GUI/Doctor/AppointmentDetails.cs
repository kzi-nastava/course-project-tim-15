using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
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
        private readonly DoctorMain Parent;
        private Appointment? Appointment;

        #region Form
        public AppointmentDetails(DoctorMain parent, Appointment appointment = null)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            PatientComboBox.Items.AddRange(GetPatients());

            if (Appointment == null)
            {
                DurationTextBox.Text = "15";
                DurationTextBox.Enabled = false;
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
            
            if (Appointment.Type == 'E')
            {
                ExaminationRadioButton.Checked = true;
                OperationRadioButton.Checked = false;
                DurationTextBox.Enabled = false;
            }
            else
            {
                ExaminationRadioButton.Checked = false;
                OperationRadioButton.Checked = true;
                DurationTextBox.Enabled = true;
            }

            IsUrgentCheckBox.Checked = Appointment.Urgent;
            DurationTextBox.Text = Appointment.Duration.ToString();
            ConfirmButton.Text = "Save";
        }
        #endregion

        private User[] GetPatients()
        {
            return UserRepository.GetInstance().Users.Where(x => x.Role.ToUpper() == User.RoleType.PATIENT.ToString()).ToArray();
        }
        private void ExaminationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if(ExaminationRadioButton.Checked)
            {
                DurationTextBox.Text = "15";
                DurationTextBox.Enabled = false;
                return;
            }
            DurationTextBox.Text = "";
            DurationTextBox.Enabled = true;
        }
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            var selectedDate = DatePicker.Value;
            var selectedTime = TimePicker.Value;
            var selectedDateTime = DateTime.Parse($"{selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day} {selectedTime.Hour}:{selectedTime.Minute}");
            
            if (!Validate(selectedDateTime))
            {
                return;
            }
            
            if (Appointment != null)
            {
                ModifyInDatabase(selectedDateTime);
                return;
            }
            CreateInDatabase(selectedDateTime);
        }
        private bool Validate(DateTime dateTime)
        {
            if(dateTime < DateTime.Now)
            {
                MessageBox.Show("Please select valid date!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(PatientComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select patient!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (AppointmentRepository.GetInstance().IsOccupied(dateTime, Parent.Doctor.ID, Convert.ToInt32(DurationTextBox.Text)))
            {
                MessageBox.Show("Already occupied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void CreateInDatabase(DateTime dateTime)
        {
            var appointment = new Appointment();
            TransferDataFromUI(appointment, dateTime);
            AppointmentRepository.GetInstance().Create(appointment);
            Parent.Enabled = true;
            Parent.InsertIntoAllAppointmentsTable(appointment);
            Close();
        }
        private void ModifyInDatabase(DateTime dateTime)
        {
            TransferDataFromUI(Appointment, dateTime);
            AppointmentRepository.GetInstance().Modify(Appointment);
            Parent.Enabled = true;
            Parent.UpdateTableRow(Appointment, Parent.AllAppointmentsTable);
            Close();
        }
        private void TransferDataFromUI(Appointment appointment, DateTime dateTime)
        {
            appointment.DoctorID = Parent.Doctor.ID;
            appointment.PatientID = (PatientComboBox.SelectedItem as User).ID;
            appointment.DateTime = dateTime;
            appointment.RoomID = 1;
            appointment.Completed = false;
            appointment.Type = ExaminationRadioButton.Checked ? 'E' : 'O';
            appointment.Duration = Convert.ToInt32(DurationTextBox.Text);
            appointment.Urgent = IsUrgentCheckBox.Checked;
            appointment.Description = "";
            appointment.IsDeleted = false;
        }

    }
}

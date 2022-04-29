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
        private Appointment? ToEdit;

        public AppointmentDetails(DoctorMain parent, Appointment appointment = null)
        {
            InitializeComponent();
            Parent = parent;
            ToEdit = appointment;
        }

        private void AddAppointmentLoad(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            DatePicker.MinDate = DateTime.Now;
            PatientPicker.Items.AddRange(GetPatients());
            if (ToEdit == null)
            {
                DurationTextBox.Text = "15";
                DurationTextBox.Enabled = false;
                return;
            }

            DatePicker.Value = ToEdit.DateTime;
            TimePicker.Value = ToEdit.DateTime;
            PatientPicker.SelectedIndex = PatientPicker.Items.IndexOf(UserRepository.GetInstance().Users.Where(x => x.ID == ToEdit.PatientID).FirstOrDefault());
            if (ToEdit.Type == 'E')
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
            IsUrgentCheckBox.Checked = ToEdit.Urgent;
            DurationTextBox.Text = ToEdit.Duration.ToString();
            SaveAppointmentButton.Text = "Save";
        }
        private User[] GetPatients()
        {
            return UserRepository.GetInstance().Users.Where(x => x.Role.ToUpper() == User.RoleType.PATIENT.ToString()).ToArray();
        }
        private void ExaminationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if((sender as RadioButton).Checked)
            {
                DurationTextBox.Text = "15";
                DurationTextBox.Enabled = false;
                return;
            }
            DurationTextBox.Text = "";
            DurationTextBox.Enabled = true;
        }
        private void SaveAppointmentButtonClick(object sender, EventArgs e)
        {
            var selectedDate = DatePicker.Value;
            var selectedTime = TimePicker.Value;
            var dateTime = DateTime.Parse($"{selectedDate.Year}-{selectedDate.Month}-{selectedDate.Day} {selectedTime.Hour}:{selectedTime.Minute}");

            if(ToEdit != null)
            {
                ModifyInDatabase(dateTime);
                return;
            }
            CreateInDatabase(dateTime);
        }
        private void CreateInDatabase(DateTime dateTime)
        {
            if (AppointmentRepository.GetInstance().IsOccupied(dateTime, Convert.ToInt32(DurationTextBox.Text)))
            {
                MessageBox.Show("Already occupied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var appointment = new Appointment();
            TransferDataFromUI(appointment, dateTime);
            AppointmentRepository.GetInstance().Create(appointment);
            Parent.Enabled = true;
            Parent.InsertIntoAppointmentsTable(appointment);
            Close();
        }
        private void ModifyInDatabase(DateTime dateTime)
        {
            if (AppointmentRepository.GetInstance().IsOccupied(dateTime, Convert.ToInt32(DurationTextBox.Text), ToEdit.ID))
            {
                MessageBox.Show("Already occupied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TransferDataFromUI(ToEdit, dateTime);
            AppointmentRepository.GetInstance().Modify(ToEdit);
            Parent.Enabled = true;
            Parent.UpdateTableRow(ToEdit, Parent.AllAppointmentsTable);
            Close();
        }
        private void TransferDataFromUI(Appointment appointment, DateTime dateTime)
        {
            appointment.DoctorID = Parent.Doctor.ID;
            appointment.PatientID = (PatientPicker.SelectedItem as User).ID;
            appointment.DateTime = dateTime;
            appointment.RoomID = 1;
            appointment.Completed = false;
            appointment.Type = ExaminationRadioButton.Checked ? 'E' : 'O';
            appointment.Duration = Convert.ToInt32(DurationTextBox.Text);
            appointment.Urgent = IsUrgentCheckBox.Checked;
            appointment.Description = "";
            appointment.IsDeleted = false;
        }

        private void AppointmentDetailsFormClosed(object sender, FormClosedEventArgs e)
        {
            Parent.Enabled = true;
        }
    }
}

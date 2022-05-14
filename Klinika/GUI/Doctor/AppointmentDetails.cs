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
        private readonly AppointmentDetailsService Service;

        public AppointmentDetails(DoctorMain parent, Appointment appointment = null)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
            Service = new AppointmentDetailsService(this);
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
            Service.FinishForm(Appointment);
            Close();
        }

    }
}

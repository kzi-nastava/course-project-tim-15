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

namespace Klinika.GUI.Patient
{
    public partial class AppointmentRecommendation : Form
    {
        private readonly PatientMain Parent;

        #region Form
        public AppointmentRecommendation(PatientMain parent)
        {
            InitializeComponent();
            Parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.FillDoctorComboBox(DoctorComboBox);
            ScheduleButton.Enabled = false;
            DoctorRadioButton.Checked = true;
            FillRecommendedAppointmentTable();
            Parent.Enabled = false;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Click functions
        private void RecommendButtonClick(object sender, EventArgs e)
        {
            if (!IsDateValid())
            {
                MessageBox.Show("Time is not valid! Please enter valid time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int doctorID = (DoctorComboBox.SelectedItem as User).ID;
            char priority = DoctorRadioButton.Checked ? 'D' : 'T';
            TimeSlot timeSlot = new TimeSlot(FromTimePicker.Value, ToTimePicker.Value);

            List<Appointment> recommended = AppointmentService.FindRecommended(doctorID, timeSlot, DeadlineDatePicker.Value, priority);
            FillRecommendedAppointmentTable(recommended);
        }
        private void ScheduleButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to create this Appoinment?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                CreateInDatabase();
                Close();
            }
        }
        #endregion

        private void FillRecommendedAppointmentTable(List<Appointment> appointments = null)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Doctor ID");
            dataTable.Columns.Add("Doctor");
            dataTable.Columns.Add("DateTime");

            if (appointments != null)
            {
                foreach (Appointment appointment in appointments)
                {
                    DataRow newRow = dataTable.NewRow();

                    newRow["Doctor ID"] = appointment.DoctorID;
                    newRow["Doctor"] = DoctorService.GetFullName(appointment.DoctorID);
                    newRow["DateTime"] = appointment.DateTime;
                    dataTable.Rows.Add(newRow);
                }
            }
            RecommendedAppointmentTable.DataSource = dataTable;
        }
        private void RecommendedAppointmentTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            ScheduleButton.Enabled = true;
        }
        private void CreateInDatabase()
        {
            Appointment appointment = new Appointment(GetSelectedDoctorID(), Parent.Patient.ID, GetSelectedDateTime());

            AppointmentRepository.GetInstance().Create(appointment);
            Parent.PersonalAppointmentsTable.Insert(appointment);
        }
        private bool IsDateValid()
        {
            return FromTimePicker.Value < ToTimePicker.Value && DeadlineDatePicker.Value > DateTime.Now;
        }
        private int GetSelectedDoctorID()
        {
            return Convert.ToInt32(RecommendedAppointmentTable.SelectedRows[0].Cells["Doctor ID"].Value);
        }
        private DateTime GetSelectedDateTime()
        {
            return Convert.ToDateTime(RecommendedAppointmentTable.SelectedRows[0].Cells["DateTime"].Value);
        }
    }
}
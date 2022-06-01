using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;
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
            UIUtilities.FillDoctorComboBox(DoctorComboBox);
            FillRecommendedAppointmentTable();
            Parent.Enabled = false;
            ScheduleButton.Enabled = false;
            DoctorRadioButton.Checked = true;
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
        #endregion

        private void ShowRecommended()
        {
            int doctorID = (DoctorComboBox.SelectedItem as User).ID;
            char priority = DoctorRadioButton.Checked ? 'D' : 'T';
            TimeSlot timeSlot = new TimeSlot(FromTimePicker.Value, ToTimePicker.Value);

            List<Appointment> recommended = AppointmentRecommendationService.Find(doctorID, timeSlot, DeadlineDatePicker.Value, priority);
            FillRecommendedAppointmentTable(recommended);
        }
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

                    newRow["Doctor ID"] = appointment.doctorID;
                    newRow["Doctor"] = DoctorService.GetFullName(appointment.doctorID);
                    newRow["DateTime"] = appointment.dateTime;
                    dataTable.Rows.Add(newRow);
                }
            }
            RecommendedAppointmentTable.DataSource = dataTable;
        }
        private void RecommendedAppointmentTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            ScheduleButton.Enabled = true;
        }
        private int GetSelectedDoctorID()
        {
            return Convert.ToInt32(RecommendedAppointmentTable.SelectedRows[0].Cells["Doctor ID"].Value);
        }
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
            Appointment appointment = new Appointment(GetSelectedDoctorID(), Parent.Patient.ID, GetSelectedDateTime());
            AppointmentService.Create(appointment);
            Parent.PersonalAppointmentsTable.Insert(appointment);
        }
    }
}
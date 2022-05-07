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
            Parent.FillDoctorComboBox(DoctorComboBox);
            ScheduleButton.Enabled = false;
            DoctorRadioButton.Checked = true;
            FillRecommendedAppointmentTable();
        }
        private void LoadForm(object sender, EventArgs e)
        {
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
                    newRow["Doctor"] = Parent.GetDoctorFullName(appointment.DoctorID);
                    newRow["DateTime"] = appointment.DateTime;
                    dataTable.Rows.Add(newRow);
                }
            }
            RecommendedAppointmentTable.DataSource = dataTable;
        }

        private void RecommendClick(object sender, EventArgs e)
        {
            if (!IsDateTimeDataValid())
            {
                MessageBox.Show("Time is not valid! Please enter valid time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int doctorID = (DoctorComboBox.SelectedItem as User).ID;
            DateTime fromTime = FromTimePicker.Value;
            DateTime untilTime = UntilTimePicker.Value;
            DateTime deadlineDate = DeadlineDatePicker.Value;
            char priority = DoctorRadioButton.Checked ? 'D' : 'T';

            List<Appointment> recommended = AppointmentServices.GetRecommended(doctorID, fromTime, untilTime, deadlineDate, priority);
            FillRecommendedAppointmentTable(recommended);
        }

        private void RecommendedAppointmentTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            ScheduleButton.Enabled = true;
        }

        private void ScheduleClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to create this Appoinment?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                CreateAppointment();
                Close();
            }
        }

        private void CreateAppointment()
        {
            int doctorID = Convert.ToInt32(RecommendedAppointmentTable.SelectedRows[0].Cells["Doctor ID"].Value);
            DateTime dateTime = Convert.ToDateTime(RecommendedAppointmentTable.SelectedRows[0].Cells["DateTime"].Value);

            Appointment appointment = new Appointment();
            appointment.ID = -1;
            appointment.DoctorID = doctorID;
            appointment.PatientID = Parent.Patient.ID;
            appointment.DateTime = dateTime;
            appointment.RoomID = 1;
            appointment.Completed = false;
            appointment.Type = 'E';
            appointment.Duration = 15;
            appointment.Urgent = false;
            appointment.Description = "";
            appointment.IsDeleted = false;
            AppointmentRepository.GetInstance().Create(appointment);
            Parent.InsertRowIntoPersonalAppointmentsTable(appointment);
        }
        private bool IsDateTimeDataValid()
        {
            return FromTimePicker.Value < UntilTimePicker.Value && DeadlineDatePicker.Value > DateTime.Now;
        }
    }
}

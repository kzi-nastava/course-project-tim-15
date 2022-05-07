using Klinika.Models;
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
            dataTable.Columns.Add("Doctor");
            dataTable.Columns.Add("DateTime");

            if (appointments != null)
            {
                foreach (Appointment appointment in appointments)
                {
                    DataRow newRow = dataTable.NewRow();

                    newRow["Doctor"] = Parent.GetDoctorFullName(appointment.DoctorID);
                    newRow["DateTime"] = appointment.DateTime;
                    dataTable.Rows.Add(newRow);
                }
            }
            RecommendedAppointmentTable.DataSource = dataTable;
        }

        private void RecommendClick(object sender, EventArgs e)
        {
            int doctorID = (DoctorComboBox.SelectedItem as User).ID;
            DateTime fromTime = FromTimePicker.Value;
            DateTime untilTime = UntilTimePicker.Value;
            DateTime deadlineDate = DeadlineDatePicker.Value;
            char priority = DoctorRadioButton.Checked ? 'D' : 'T';

            List<Appointment> recommended = AppointmentServices.GetRecommended(doctorID, fromTime, untilTime, deadlineDate, priority);
            FillRecommendedAppointmentTable(recommended);
        }
    }
}

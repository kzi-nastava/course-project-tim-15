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
    public partial class DoctorMain : Form
    {
        private User Doctor;
        private List<Appointment> Appointments
        {
            get
            {
                return AppointmentRepository.GetInstance().Appointments;
            }
        }
        public DoctorMain(User doctor)
        {
            InitializeComponent();
            Doctor = doctor;
        }

        #region All Appointments
        private void FillAllAppointmentsTable()
        {
            DataTable? allAppointments = AppointmentRepository.GetAll(Doctor.ID, User.RoleType.DOCTOR);
            if (allAppointments != null)
            {
                FillTableWithPatientData(allAppointments);
                FixAppointmentTypeField(allAppointments);
                allAppointments.Columns.Remove("DoctorID");
                allAppointments.Columns.Remove("PatientID");
                allAppointments.Columns.Remove("RoomID");
                allAppointments.Columns.Remove("Completed");
                allAppointments.Columns.Remove("IsDeleted");
                allAppointments.Columns.Remove("Description");

                AllAppointmentsTable.DataSource = allAppointments;

                AllAppointmentsTable.Columns["ID"].Width = 50;
                AllAppointmentsTable.Columns["DateTime"].MinimumWidth = 150;

                AllAppointmentsTable.ClearSelection();
            }
        }
        private void FixAppointmentTypeField(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                switch (row["Type"])
                {
                    case "O":
                        row["Type"] = "Operation";
                        break;
                    default:
                        row["Type"] = "Examination";
                        break;
                }
            }
        }
        private void FillTableWithPatientData(DataTable dt)
        {
            dt.Columns.Add("Patient Name");
            dt.Columns["Patient Name"].SetOrdinal(1);
            foreach (DataRow row in dt.Rows)
            {
                row["Patient Name"] = GetPatientName(Convert.ToInt32(row["PatientID"]));
            }
        }
        private string GetPatientName(int ID)
        {
            var patient = UserRepository.GetInstance().Users.Where(x => x.ID == ID).FirstOrDefault();
            return $"{patient.Name} {patient.Surname}";
        }
        private void AllAppointmentsTableRowSelected(object sender, DataGridViewCellEventArgs e)
        {
            EditAppointmentButton.Enabled = true;
            DeleteAppointmentButton.Enabled = true;
        }
        #endregion

        private void DoctorMainLoad(object sender, EventArgs e)
        {
            FillAllAppointmentsTable();
            EditAppointmentButton.Enabled = false;
            DeleteAppointmentButton.Enabled = false;

        }
        private void DoctorMainFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddAppointmentButtonClick(object sender, EventArgs e)
        {
            new AddAppointment(this).Show();
        }
    }
}

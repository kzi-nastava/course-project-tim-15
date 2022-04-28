using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Models;

namespace Klinika.GUI.Patient
{
    public partial class PatientMain : Form
    {
        private User Patient { get; set; }
        public PatientMain(User patient)
        {
            InitializeComponent();
            Patient = patient;
        }

        private void PatientMainLoad(object sender, EventArgs e)
        {
            DataTable? allAppointments = AppointmentRepository.GetAll(Patient.ID, User.RoleType.PATIENT);
            if (allAppointments != null)
            {
                FillTableWithDoctorData(allAppointments);
                FillAppointmentTypeName(allAppointments);

                allAppointments.Columns.Remove("DoctorID");
                allAppointments.Columns.Remove("PatientID");
                allAppointments.Columns.Remove("Completed");
                allAppointments.Columns.Remove("IsDeleted");
                allAppointments.Columns.Remove("Description");

                YourAppointmentsTable.DataSource = allAppointments;

                YourAppointmentsTable.Columns["ID"].Width = 45;
                YourAppointmentsTable.Columns["DateTime"].MinimumWidth = 150;

                YourAppointmentsTable.ClearSelection();
            }
        }

        private void FillAppointmentTypeName(DataTable dataTable)
        {
            foreach(DataRow row in dataTable.Rows)
            {
                if(row["Type"].ToString() == "E")
                {
                    row["Type"] = "Examination";
                }
                else
                {
                    row["Type"] = "Operation";
                }
            }
        }

        private void FillTableWithDoctorData(DataTable dataTable)
        {
            dataTable.Columns.Add("Doctor Name");
            dataTable.Columns["Doctor Name"].SetOrdinal(1);
            foreach(DataRow row in dataTable.Rows)
            {
                var doctor = GetDoctor(Convert.ToInt32(row["DoctorID"]));
                row["Doctor Name"] = doctor.Name + " " + doctor.Surname;
            }
        }

        private User? GetDoctor(int ID)
        {
            return UserRepository.GetInstance().Users.Where(x => x.ID == ID).FirstOrDefault();
        }

        private void PatientMainFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DeleteAppointment_Click(object sender, EventArgs e)
        {
            DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to delete selected appointment?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(deleteConfirmation == DialogResult.Yes)
            { 
                int ID = Convert.ToInt32(YourAppointmentsTable.SelectedRows[0].Cells["ID"].Value);
                var toDelete = Appointments.Where(x => x.ID == ID).FirstOrDefault();

                System.Diagnostics.Debug.WriteLine(DateTime.Now.AddDays(1).Date.ToString());

                if (DateTime.Now.AddDays(1).Date >= toDelete.DateTime.Date)
                {
                    DialogResult deniedDelete = MessageBox.Show("You can't delete this appointment.", "Denied Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    AppointmentRepository.Delete(toDelete.ID);

                    PatientRequest patientRequest = new PatientRequest(-1, toDelete.PatientID, toDelete.ID, 'D', "", true);
                    PatientRequestRepository.Create(patientRequest);
                }
            }
        }
    }
}

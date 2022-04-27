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
        private User Doctor { get; set; }
        public DoctorMain(User doctor)
        {
            InitializeComponent();
            Doctor = doctor;
        }

        private void DoctorMainLoad(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LOAD");
            DataTable allAppointments = AppointmentRepository.GetAll(Doctor.ID, User.RoleType.DOCTOR);
            if (AllAppointmentsTable != null)
            {
                allAppointments.Columns.Add("test");
                foreach(DataRow row in allAppointments.Rows)
                {
                    row["test"] = "test";
                }
                AllAppointmentsTable.DataSource = allAppointments;
                AllAppointmentsTable.ClearSelection();
            }

        }
    }
}

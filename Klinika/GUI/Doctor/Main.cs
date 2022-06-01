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
    public partial class Main : Form
    {
        public Roles.Doctor doctor { get; }
        public Main(int doctorID)
        {
            InitializeComponent();
            doctor = DoctorService.GetById(doctorID);
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void AllAppointmetnsButton_Click(object sender, EventArgs e)
        {
            new ViewAllAppointments(this).Show();
        }
        private void ViewScheduleButton_Click(object sender, EventArgs e)
        {
            new ViewSchedule(this).Show();
        }
        private void UnapprovedDrugsButton_Click(object sender, EventArgs e)
        {

        }
        private void VacationRequestButton_Click(object sender, EventArgs e)
        {

        }
    }
}
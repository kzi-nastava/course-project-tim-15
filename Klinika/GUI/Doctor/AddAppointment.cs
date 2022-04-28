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
    public partial class AddAppointment : Form
    {
        private readonly DoctorMain Parent;
        public AddAppointment(DoctorMain parent)
        {
            InitializeComponent();
            Parent = parent;
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

        private void AddAppointmentLoad(object sender, EventArgs e)
        {
            DurationTextBox.Text = "15";
            DurationTextBox.Enabled = false;
            PatientPicker.Items.AddRange(GetPatients());
        }
        private User[] GetPatients()
        {
            return UserRepository.GetInstance().Users.Where(x => x.Role.ToUpper() == User.RoleType.PATIENT.ToString()).ToArray();
        }
    }
}

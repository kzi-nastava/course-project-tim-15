using Klinika.Repositories;
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
    public partial class MedicalRecord : Form
    {
        private readonly DoctorMain Parent;
        private Models.MedicalRecord Record;
        public MedicalRecord(DoctorMain parent, int patientId)
        {
            InitializeComponent();
            Parent = parent;
            Record = MedicalRecordRepository.Get(patientId);
        }
        private void MedicalRecordLoad(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            PatientNameLabel.Text = Parent.GetPatientName(Record.ID);
            BloodTypeLabel.Text = Record.BloodType;
            HeightLabel.Text = $"{Record.Height}cm";
            WeightLabel.Text = $"{Record.Weight}kg";
        }
        private void MedicalRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
    }
}

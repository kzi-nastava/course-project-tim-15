using Klinika.Models;
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
            FillAnamnesesTable();
        }
        private void FillAnamnesesTable()
        {
            DataTable anamnesesData = new DataTable();
            anamnesesData.Columns.Add("ID");
            anamnesesData.Columns.Add("Description");
            anamnesesData.Columns.Add("Symptoms");
            anamnesesData.Columns.Add("Conclusion");
            
            foreach (Anamnesis anamnesis in Record.Anamneses)
            {
                DataRow newRow = anamnesesData.NewRow();
                newRow["ID"] = anamnesis.ID;
                newRow["Description"] = anamnesis.Description;
                newRow["Symptoms"] = anamnesis.Symptoms;
                newRow["Conclusion"] = anamnesis.Conclusion;
                anamnesesData.Rows.Add(newRow);
            }
            AnamnesesTable.DataSource = anamnesesData;

            AnamnesesTable.ClearSelection();

        }
        private void MedicalRecordFormClosing(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        private void AnamnesesTableSelectionChanged(object sender, EventArgs e)
        {
            AnamnesesTable.ClearSelection();
        }
    }
}

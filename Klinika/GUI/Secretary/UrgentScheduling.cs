using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Services;
using Klinika.Repositories;
using Klinika.Models;
using Klinika.Roles;

namespace Klinika.GUI.Secretary
{
    public partial class UrgentScheduling : Form
    {
        public UrgentScheduling()
        {
            InitializeComponent();
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            TryScheduling();
        }

        private void FillInitialSelectionFields()
        {
            PatientRepository.FillPatientSelectionList(patientSelection);
            SecretaryService.FillSpecializationSelectionList(specializationSelection);
            patientSelection.SelectedIndex = 0;
            specializationSelection.SelectedIndex = 0;
        }

        private void UrgentScheduling_Load(object sender, EventArgs e)
        {
            FillInitialSelectionFields();
        }


        private void TryScheduling()
        {
            TimeSlot slot = new TimeSlot(DateTime.Now,DateTime.Now.AddHours(2));
            int specializationId = Convert.ToInt32(SecretaryService.ExtractID(specializationSelection.SelectedItem.ToString()));
            Roles.Doctor availableDoctor = DoctorRepository.GetInstance().GetFirstUnoccupied(slot, specializationId);
            if (availableDoctor == null)
            {

            }
        }
    }
}

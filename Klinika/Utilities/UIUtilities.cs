using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Interfaces;

namespace Klinika.Utilities
{
    internal class UIUtilities
    {
        
        public static int ExtractID(string objectWithId)
        {
            return Convert.ToInt32(objectWithId.Split('.')[0]);
        }

        public static void FillPatientSelectionList(ComboBox patientSelection)
        {
            PatientService patientService = StartUp.serviceProvider.GetService<PatientService>();
            foreach (Patient patient in patientService.GetAll())
            {
                patientSelection.Items.Add(patient.GetIdAndFullName());
            }
        }
        public static void FillDoctorComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(StartUp.serviceProvider.GetService<IUserRepo>().GetDoctors().ToArray());
            comboBox.SelectedIndex = 0;
        }
        public static void FillPatientComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(StartUp.serviceProvider.GetService<IUserRepo>().GetPatients().ToArray());
            comboBox.SelectedIndex = 0;
        }
        public static void FillSpecializationComboBox(ComboBox comboBox, int index = -1)
        {
            var specializations = StartUp.serviceProvider.GetService<SpecializationService>().GetAll().ToArray();
            comboBox.Items.AddRange(specializations); 
            comboBox.SelectedIndex = index;
        }
        public static void FillSpecializedDoctorComboBox(ComboBox comboBox, int specializationID)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(StartUp.serviceProvider.GetService<SpecializationService>().GetSpecializedDoctors(specializationID));
            comboBox.SelectedIndex = -1;
        }
        public static bool Confirm(string message)
        {
            var result = MessageBoxUtilities.ShowConfirmationMessage(message);
            if (result == DialogResult.Yes) return true;
            return false;
        }
    }
}

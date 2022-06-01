using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using System.Data;

namespace Klinika.Utilities
{
    internal class UIUtilities
    {
        public static void Fill(DataGridView table, DataTable data)
        {
            table.DataSource = data;
            table.ClearSelection();
        }

        public static int ExtractID(string objectWithId)
        {
            return Convert.ToInt32(objectWithId.Split('.')[0]);
        }

        public static object GetCellValue(DataGridView table, string columnName)
        {
            return table.SelectedRows[0].Cells[columnName].Value;
        }

        public static void FillPatientSelectionList(ComboBox patientSelection)
        {
            foreach (KeyValuePair<int, Patient> pair in PatientRepository.idPatientPairs)
            {
                patientSelection.Items.Add(pair.Value.GetIdAndFullName());
            }
        }
        public static void FillDoctorComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(UserRepository.GetDoctors().ToArray());
            comboBox.SelectedIndex = 0;
        }
        public static void FillPatientComboBox(ComboBox comboBox)
        {
            comboBox.Items.AddRange(UserRepository.GetPatients().ToArray());
            comboBox.SelectedIndex = 0;
        }
        public static void FillSpecializationComboBox(ComboBox comboBox)
        {
            var specializations = SpecializationService.GetAll().ToArray();
            comboBox.Items.AddRange(specializations); 
            comboBox.SelectedIndex = -1;
        }
        public static void FillSpecializedDoctorComboBox(ComboBox comboBox, int specializationID)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(DoctorRepository.GetSpecializedDoctors(specializationID));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;
using Klinika.Repositories;
using System.Data;
using Klinika.Models;

namespace Klinika.Services
{
    internal class UIService
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

        public static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowInformationMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowConfirmationMessage(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static object GetCellValue(DataGridView table, string columnName)
        {
            return table.SelectedRows[0].Cells[columnName].Value;
        }

        public static void FillPatientSelectionList(ComboBox patientSelection)
        {
            foreach (KeyValuePair<int, Roles.Patient> pair in PatientRepository.IDPatientPairs)
            {
                patientSelection.Items.Add(pair.Value.GetIdAndFullName());
            }
        }

    }
}

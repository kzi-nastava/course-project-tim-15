using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Roles;
using Klinika.Repositories;
using System.Data;
using Klinika.Models;

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
            foreach (KeyValuePair<int, Patient> pair in PatientRepository.IDPatientPairs)
            {
                patientSelection.Items.Add(pair.Value.GetIdAndFullName());
            }
        }

    }
}

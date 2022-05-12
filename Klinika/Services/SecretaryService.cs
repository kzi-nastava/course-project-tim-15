﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Exceptions;
using Klinika.Roles;
using Klinika.Repositories;
using Klinika.Models;

namespace Klinika.Services
{
    internal class SecretaryService
    {

        public static void FillPatientSelectionList(ComboBox patientSelection,Dictionary<int,Patient> IDPatientPairs)
        {
            foreach(KeyValuePair<int,Patient> pair in IDPatientPairs)
            {
                string patient = pair.Key + ". " + pair.Value.Name + " " + pair.Value.Surname;
                patientSelection.Items.Add(patient);
            }
        }

        public static int ExtractID(string objectWithId)
        {
            return Convert.ToInt32(objectWithId.Split('.')[0]);
        }

        public static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowConfirmationMessage(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }


        public static object GetCellValue(DataGridView table,string columnName)
        {
            return table.SelectedRows[0].Cells[columnName].Value;
        }
        
        public static void Fill(DataGridView table,DataTable data)
        {
            table.DataSource = data;
            table.ClearSelection();
        }
    }
}

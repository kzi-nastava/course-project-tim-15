﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;

namespace Klinika.Forms
{
    public class DrugsDataGridView : DataGridView
    {
        private List<Drug> Drugs;
        public DrugsDataGridView() : base()
        {
            Drugs = new List<Drug>();
        }
        public void Fill(List<Drug> drugs)
        {
            Drugs = drugs;

            DataTable drugsData = new DataTable();
            drugsData.Columns.Add("ID");
            drugsData.Columns.Add("Name");
            drugsData.Columns.Add("Ingredients");

            foreach (Drug drug in drugs)
            {
                DataRow newRow = drugsData.NewRow();
                newRow["ID"] = drug.ID;
                newRow["Name"] = drug.Name;
                newRow["Ingredients"] = drug.GetIngredientsAsString();
                drugsData.Rows.Add(newRow);
            }

            DataSource = drugsData;
            Columns[0].Width = 30;
            Columns[1].Width = 90;
            ClearSelection();
        }
        public int GetSelectedId()
        {
            if(SelectedRows.Count == 0) return -1;
            int selectedId = Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
            return selectedId;
        }
        public Drug GetSelectedDrug()
        {
            int selectedID = GetSelectedId();
            if(selectedID == -1) return null;
            return Drugs.Where(x => x.ID == selectedID).FirstOrDefault();
        }
    }
}

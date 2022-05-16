using Klinika.Models;
using Klinika.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    public class DrugService
    {
        public static void FillTable(DataGridView table, bool showUnapproved = false)
        {
            DataTable drugsData = new DataTable();
            drugsData.Columns.Add("ID");
            drugsData.Columns.Add("Name");
            drugsData.Columns.Add("Ingredients");

            foreach (Drug drug in DrugRepository.Instance.Drugs.Where(x => x.Approved == (showUnapproved ? "C" : "A")))
            {
                DataRow newRow = drugsData.NewRow();
                newRow["ID"] = drug.ID;
                newRow["Name"] = drug.Name;
                newRow["Ingredients"] = drug.GetIngredientsAsString();
                drugsData.Rows.Add(newRow);
            }

            table.DataSource = drugsData;
            table.Columns[0].Width = 30;
            table.Columns[1].Width = 90;
            table.ClearSelection();
        }
        public static Drug GetSelected(DataGridView table)
        {
            int drugId = Convert.ToInt32(table.SelectedRows[0].Cells["ID"].Value);
            var selectedDrug = DrugRepository.Instance.Drugs.Where(x => x.ID == drugId).FirstOrDefault();
            return selectedDrug;
        }
        public static void ApproveDrug(int id)
        {
            var msgBox = MessageBox.Show("Are you sure you want to approve this drug?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgBox == DialogResult.No) return;
            DrugRepository.Instance.ModifyType(id, 'A');
        }
        public static void DenyDrug(int id, string description)
        {
            var msgBox = MessageBox.Show("Are you sure you want to deny this drug?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgBox == DialogResult.No) return;
            DrugRepository.Instance.ModifyType(id, 'D');
            DrugRepository.CreateUnapproved(id, description);
        }
    }
}

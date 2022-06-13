using Klinika.Core;
using Klinika.Drugs.Models;
using Klinika.Drugs.Services;
using System.Data;

namespace Klinika.GUI.Manager
{
    public partial class ChangeDrug : Form
    {
        DataTable table;
        List<EnhancedComboBoxItem> ingredients;
        Drug drug;
        Main main;
        public ChangeDrug(Drug d, Main m)
        {
            table = new DataTable();
            main = m;
            drug = d;
            InitializeComponent();
        }

        private void ChangeDrug_Load(object sender, EventArgs e)
        {
            ingredients = IngredientService.GetIngredientList();
            foreach(EnhancedComboBoxItem ingredient in ingredients)
            {
                ingredientsBox.Items.Add(ingredient);
            }
            ingredientsBox.SelectedIndex = 0;
            nameBox.Text = drug.name;

            table.Columns.Add("id", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Type", typeof(string));
            if (drug.id != -1)
            {
                addDrugButton.Text = "Modify";
                List<Ingredient> ingredients = DrugService.GetIngredients(drug.id);
                foreach(Ingredient ingredient in ingredients)
                {
                    DataRow dr = table.NewRow();

                    dr[0] = ingredient.id;
                    dr[1] = ingredient.name;
                    dr[2] = ingredient.type;

                    table.Rows.Add(dr);
                }
            }
            if (drug.approved == "D")
            {
                richTextBox1.Visible = true;
                richTextBox1.Text = DrugService.GetNote(drug.id);
            }
            ingredientsTable.DataSource = table;
            ingredientsTable.Columns[0].Visible = false;
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            Ingredient ingredient = (Ingredient)(((EnhancedComboBoxItem)ingredientsBox.Items[ingredientsBox.SelectedIndex]).value);
            if (IngredientService.CheckTable(table, ingredient.id))
            {
                DataRow dr = table.NewRow();
                dr[0] = ingredient.id;
                dr[1] = ingredient.name;
                dr[2] = ingredient.type;
                table.Rows.Add(dr);
            }

        }

        private void removeIngredientButton_Click(object sender, EventArgs e)
        {
            string id = ingredientsTable.SelectedRows[0].Cells["id"].Value.ToString();

            for (int i = table.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = table.Rows[i];
                if (dr["id"].ToString() == id)
                {
                    table.Rows.Remove(dr);
                    break;
                }
            }
            //table.AcceptChanges();
            ingredientsTable.DataSource = table;
        }

        private void addDrugButton_Click(object sender, EventArgs e)
        {
            if(nameBox.Text != "")
            {
                drug.name = nameBox.Text;
            }
            DrugService.AddDrug(drug, table); 
            MessageBox.Show("Drug sent for approval!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

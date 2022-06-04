using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Manager
{
    public partial class ChangeIngredient : Form
    {
        int id;
        Main main;
        public ChangeIngredient(int id, Main m)
        {
            main = m;
            if (id == -1)
            {
                button.Text = "Modify";
            }
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Models.Ingredient ingredient = new Models.Ingredient();
            ingredient.id = id;
            ingredient.name = nameBox.Text;
            ingredient.type = typeBox.Text;
            Services.IngredientService.Modify(ingredient);
            main.Main_Load(null, EventArgs.Empty);
            if (id == -1)
            {
                MessageBox.Show("Ingredient successfully modified!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ingredient successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void ChangeIngredient_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class ChangeDrug : Form
    {
        List<Models.EnhancedComboBoxItem> ingredients;
        Models.Drug drug;
        Main main;
        public ChangeDrug(int id, Main m)
        {
            main = m;
            drug = new Models.Drug();
            drug.id = id;
            InitializeComponent();
        }

        private void ChangeDrug_Load(object sender, EventArgs e)
        {
            ingredients = Services.IngredientService.GetIngredientList();
            foreach(Models.EnhancedComboBoxItem ingredient in ingredients)
            {
                ingredientsBox.Items.Add(ingredient);
            }
        }
    }
}

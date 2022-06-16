using Klinika.Drugs.Models;
using Klinika.Drugs.Services;

namespace Klinika.GUI.Manager
{
    public partial class ChangeIngredient : Form
    {
        int id;
        Main main;
        public ChangeIngredient(int id, Main m)
        {
            this.id = id;
            main = m;
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.id = id;
            ingredient.name = nameBox.Text;
            ingredient.type = typeBox.Text;

            main.Main_Load(null, EventArgs.Empty);
            if (id != -1)
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

            if (id != -1)
            {
                button1.Text = "Modify";
            }
        }
    }
}

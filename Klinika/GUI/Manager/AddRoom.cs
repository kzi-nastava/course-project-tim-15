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
    public partial class AddRoom : Form
    {
        public Main main;
        public AddRoom(Main m)
        {
            main = m;
            InitializeComponent();
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
            for(int i = 1; i < Repositories.RoomRepository.types.Count + 1; i++)
            {
                typeComboBox.Items.Add(Repositories.RoomRepository.types[i]);
            }
            typeComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Get type key from value
            int typeId = Repositories.RoomRepository.types.FirstOrDefault(x => x.Value == typeComboBox.Text).Key;
            Repositories.RoomRepository.Create(typeId, int.Parse(numberTextBox.Text));
            MessageBox.Show("Room successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            main.Main_Load(null, EventArgs.Empty);
            Close();
        }
    }
}

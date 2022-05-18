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
    public partial class Merge : Form
    {
        Models.Renovation renovation;
        public Merge(Models.Renovation r)
        {
            InitializeComponent();
            renovation = r;
        }

        private void Merge_Load(object sender, EventArgs e)
        {
            List<Models.RoomComboBoxItem> rooms = Services.RoomServices.GetRooms();
            foreach (Models.RoomComboBoxItem room in rooms)
            {
                if (int.Parse(room.value.ToString()) != renovation.id)
                    roomComboBox.Items.Add(room);
            }
            roomComboBox.SelectedIndex = 0;
        }

        private void pickButton_Click(object sender, EventArgs e)
        {
            renovation.secondId = int.Parse(((Models.RoomComboBoxItem)roomComboBox.Items[roomComboBox.SelectedIndex]).value.ToString());
            if (!Services.RoomServices.IsRoomRenovating(renovation.secondId, renovation.from, renovation.to))
            {
                if (Repositories.RoomRepository.Renovate(renovation))
                {
                    MessageBox.Show("Room successfully set for renovation!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid input.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Can not renovate this room at this time!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

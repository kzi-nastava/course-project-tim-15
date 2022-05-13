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
    public partial class PickDate : Form
    {
        GUI.Manager.Main main;
        public PickDate(GUI.Manager.Main m)
        {
            main = m;
            InitializeComponent();
        }

        private void PickDate_Load(object sender, EventArgs e)
        {
            dateTimePicker.MinDate = DateTime.Now;
            List<Models.RoomComboBoxItem> rooms = Repositories.RoomRepository.GetRooms();
            foreach (Models.RoomComboBoxItem room in rooms)
            {
                if(int.Parse(room.value.ToString()) != main.transfer.fromId)
                    roomComboBox.Items.Add(room);
            }
            roomComboBox.SelectedIndex = 0;
        }

        private bool TransferReady()
        {
            bool ok = true;
            if (!int.TryParse(quantityTextBox.Text.Trim(), out _))
            {
                MessageBox.Show("You must choose a number for quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            else if (main.transfer.quantity == 0)
            {
                MessageBox.Show("You must choose a not 0 value for quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            else if (int.Parse(quantityTextBox.Text.Trim()) > main.transfer.maxQuantity)
            {
                MessageBox.Show("Can not transfer that much.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (TransferReady())
            {
                main.transfer.quantity = int.Parse(quantityTextBox.Text);
                main.transfer.transfer = dateTimePicker.Value.Date;
                if (main.transfer.transfer.Date == DateTime.Now.Date)
                {
                    Repositories.EquipmentRepository.Transfer(main.transfer);
                }
                else
                {
                    Repositories.EquipmentRepository.TransferRequest(main.transfer);
                }

                main.Main_Load(null, EventArgs.Empty);
                this.Close();
            }
        }

        private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            main.transfer.toId = int.Parse(((Models.RoomComboBoxItem)roomComboBox.Items[roomComboBox.SelectedIndex]).value.ToString());
        }
    }
}

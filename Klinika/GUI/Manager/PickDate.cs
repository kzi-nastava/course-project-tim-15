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
        Models.EquipmentTransfer transfer;
        GUI.Manager.Main main;
        public PickDate(Models.EquipmentTransfer t, GUI.Manager.Main m)
        {
            transfer = t;
            main = m;
            InitializeComponent();
        }

        private void PickDate_Load(object sender, EventArgs e)
        {
            dateTimePicker.MinDate = DateTime.Now;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            main.transfer.quantity = int.Parse(quantityTextBox.Text);
            //ADD DATE
        }
    }
}

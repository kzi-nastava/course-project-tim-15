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
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            main.transfer.quantity = int.Parse(quantityTextBox.Text);
            //ADD DATE
        }
    }
}

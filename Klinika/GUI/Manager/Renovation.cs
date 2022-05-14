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
    public partial class Renovation : Form
    {
        Main main;
        Models.Renovation renovation;
        public Renovation(int id, Main m)
        {
            InitializeComponent();
            renovation = new Models.Renovation();
            renovation.id = id;
            main = m;
        }

        private void Renovation_Load(object sender, EventArgs e)
        {
            noneRadio.Select();
        }

        public bool CheckForm()
        {
            bool ok = true;
            if(fromDateTimePicker.Value.Date >= toDateTimePicker.Value.Date)
            {
                MessageBox.Show("Invalid dates.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckForm())
            {
                renovation.from = fromDateTimePicker.Value.Date;
                renovation.to = toDateTimePicker.Value.Date;
                if (noneRadio.Checked)
                {
                    renovation.advanced = 0;
                }
                else if (mergeRadio.Checked)
                {
                    renovation.advanced = 1;
                }
                else if (splitRadio.Checked)
                {
                    renovation.advanced = 2;
                }
            }
        }
    }
}

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
        public Main main;
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
            fromDateTimePicker.MinDate = DateTime.Now;
            toDateTimePicker.MinDate = DateTime.Now;
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
                if(!Services.RoomServices.IsRoomRenovating(renovation.id, renovation.from, renovation.to))
                {
                    if (noneRadio.Checked)
                    {
                        renovation.advanced = 0;
                        if (Repositories.RoomRepository.Renovate(renovation))
                        {
                            MessageBox.Show("Room successfully set for renovation!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            main.Main_Load(null, EventArgs.Empty);
                            this.Close();
                        }
                    }
                    else if (mergeRadio.Checked)
                    {
                        renovation.advanced = 1;
                        new Merge(renovation).Show();
                        this.Close();
                    }
                    else if (splitRadio.Checked)
                    {
                        renovation.advanced = 2;
                        new Split(renovation).Show();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Can not renovate at this time!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Can not renovate at this time!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

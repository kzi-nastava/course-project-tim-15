using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Doctor
{
    public partial class DoctorMain : Form
    {
        public DoctorMain(User doctor)
        {
            InitializeComponent();
            
        }

        private void DoctorMainLoad(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LOAD");

        }
    }
}

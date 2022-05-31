using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Patient
{
    public partial class Questionnaire : Form
    {
        private readonly PatientMain Parent;

        #region Form
        public Questionnaire(PatientMain parent)
        {
            InitializeComponent();
            Parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        private void SendButton_Click(object sender, EventArgs e)
        {

        }

        private void NotificationsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

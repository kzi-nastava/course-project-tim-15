using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Requests.Models;
using Klinika.Core.Utilities;

namespace Klinika.GUI.Secretary
{
    public partial class VacationRequestDenialReason : Form
    {
        private VacationRequest selected;
        public VacationRequestDenialReason(VacationRequest selected)
        {
            this.selected = selected;
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e) => Confirm();

        private void Confirm()
        {
            if(denialReasonField.Text == "")
            {
                MessageBoxUtilities.ShowErrorMessage("Please fill the reason for denial field!");
                return;
            }
            selected.denyReason = denialReasonField.Text;
            Close();
        }
    }
}

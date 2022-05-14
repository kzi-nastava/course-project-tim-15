using Klinika.Models;
using Klinika.Repositories;
using Klinika.Services;
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
    public partial class PrescriptionIssuing : Form
    {
        internal readonly MedicalRecord Parent;
        private readonly PrescriptionService Service;

        #region Form
        public PrescriptionIssuing(MedicalRecord parent)
        {
            InitializeComponent();
            Parent = parent;
            Service = new PrescriptionService(this);
        }
        private void LoadForm(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            PrescriptionStartDatePicker.MinDate = DateTime.Now;
            PrescriptionEndDatePicker.MinDate = DateTime.Now;
            PrescriptionService.FillTable(DrugsTable);
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            Parent.Enabled = true;
        }
        #endregion

        #region Prescript
        private void PrescriptButtonClick(object sender, EventArgs e)
        {
            Service.FinishForm();
            Close();
        }
        #endregion
    }
}
using Klinika.Models;
using Klinika.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klinika.Services;

namespace Klinika.GUI.Secretary
{
    internal partial class ModificationRequestDetails : Form
    {
        private PatientModificationRequest selected;

        public ModificationRequestDetails(PatientModificationRequest selected)
        {
            InitializeComponent();
            this.selected = selected;
        }

        private void ModificationRequestDetails_Load(object sender, EventArgs e)
        {
            FillFields();
        }

        private void FillFields()
        {
            oldAppointment.Value = selected.oldAppointment;
            newAppointment.Value = selected.newAppointment;
            oldDoctorField.Text = DoctorService.GetFullName(selected.oldDoctorID);
            newDoctorField.Text = DoctorService.GetFullName(selected.newDoctorID);
        }
    }
}

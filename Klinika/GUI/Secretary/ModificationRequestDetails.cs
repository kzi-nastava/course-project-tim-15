using Klinika.Entities;
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

namespace Klinika.GUI.Secretary
{
    public partial class ModificationRequestDetails : Form
    {
        private PatientModificationRequest selected;
        public ModificationRequestDetails(mainWindow parent)
        {
            InitializeComponent();
            int requestID = Convert.ToInt32(parent.requestsTable.SelectedRows[0].Cells["ID"].Value);
            selected = RequestRepository.IdRequestPairs[requestID];

        }

        private void ModificationRequestDetails_Load(object sender, EventArgs e)
        { 
          
            oldAppointment.Value = selected.oldAppointment;
            newAppointment.Value = selected.newAppointment;
            oldDoctorField.Text = DoctorRepository.GetNameSurname(selected.oldDoctorID);
            newDoctorField.Text = DoctorRepository.GetNameSurname(selected.newDoctorID);

        }
    }
}

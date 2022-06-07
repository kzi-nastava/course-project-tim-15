using Klinika.Models;
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

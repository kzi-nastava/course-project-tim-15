using Microsoft.Extensions.DependencyInjection;
using Klinika.Users.Services;
using Klinika.Requests.Models;
using Klinika.Core.Dependencies;

namespace Klinika.GUI.Secretary
{
    internal partial class ModificationRequestDetails : Form
    {
        private PatientModificationRequest selected;
        private readonly DoctorService doctorService;

        public ModificationRequestDetails(PatientModificationRequest selected)
        {
            InitializeComponent();
            this.selected = selected;
            doctorService = StartUp.serviceProvider.GetService<DoctorService>();
        }

        private void ModificationRequestDetails_Load(object sender, EventArgs e) => FillFields();

        private void FillFields()
        {
            oldAppointment.Value = selected.oldAppointment;
            newAppointment.Value = selected.newAppointment;
            oldDoctorField.Text = doctorService.GetFullName(selected.oldDoctorID);
            newDoctorField.Text = doctorService.GetFullName(selected.newDoctorID);
        }
    }
}

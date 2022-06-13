using Klinika.Appointments.Models;
using Klinika.Core.Dependencies;
using Klinika.Core.Utilities;
using Klinika.Users.Models;
using Klinika.Users.Services;
using Microsoft.Extensions.DependencyInjection;
using RDoctor = Klinika.Users.Models.Doctor;

namespace Klinika.GUI.Patient
{
    public partial class SearchDoctors : Form
    {
        private readonly DoctorService? doctorService;
        internal readonly Main parent;
        RDoctor.Filters selectedDoctorFilter = RDoctor.Filters.BY_NAME;
        internal Users.Models.Patient patient { get { return parent.patient; } }
        public SearchDoctors(Main parent)
        {
            InitializeComponent();
            doctorService = StartUp.serviceProvider.GetService<DoctorService>();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            DoctorNameRadioButton.Checked = true;
            UIUtilities.FillSpecializationComboBox(DoctorSpecializationComboBox, 0);
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => parent.Enabled = true;
        private void SetDoctorFilter(RDoctor.Filters selected)
        {
            DoctorNameTextBox.Enabled = selected == RDoctor.Filters.BY_NAME;
            DoctorSurnameTextBox.Enabled = selected == RDoctor.Filters.BY_SURNAME;
            DoctorSpecializationComboBox.Enabled = selected == RDoctor.Filters.BY_SPECIALIZATION;

            DoctorNameTextBox.Text = "";
            DoctorSurnameTextBox.Text = "";
            DoctorsTable.DataSource = null;

            selectedDoctorFilter = selected;
        }
        private void DoctorNameRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (!DoctorNameRadioButton.Checked) return;
            SetDoctorFilter(RDoctor.Filters.BY_NAME);
        }
        private void DoctorSurnameRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (!DoctorSurnameRadioButton.Checked) return;
            SetDoctorFilter(RDoctor.Filters.BY_SURNAME);
        }
        private void DoctorSpecializationRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (!DoctorSpecializationRadioButton.Checked) return;
            SetDoctorFilter(RDoctor.Filters.BY_SPECIALIZATION);
        }
        private void NewAppointmentButtonClick(object sender, EventArgs e)
        {
            var doctorID = DoctorsTable.GetSelectedID();
            var dto = new PersonalAppointmentDTO(this, new Appointment(patient.id, doctorID), true, false);
            new PersonalAppointment(dto).Show();
        }
        private void DoctorSearchButtonClick(object sender, EventArgs e)
        {
            List<RDoctor> result = selectedDoctorFilter switch
            {
                RDoctor.Filters.BY_NAME => doctorService.SearchByName(DoctorNameTextBox.Text),
                RDoctor.Filters.BY_SURNAME => doctorService.SearchBySurname(DoctorSurnameTextBox.Text),
                RDoctor.Filters.BY_SPECIALIZATION => doctorService.SearchBySpecialization(GetSelectedSpecializationID()),
                _ => new List<RDoctor>()
            };
            DoctorsTable.Fill(result);
        }
        private void DoctorsTableCellClick(object sender, DataGridViewCellEventArgs e) => NewAppointmentButton.Enabled = true;
        private int GetSelectedSpecializationID() => (DoctorSpecializationComboBox.SelectedItem as Specialization).id;
    }
}

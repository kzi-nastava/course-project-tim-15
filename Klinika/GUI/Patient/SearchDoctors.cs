using RDoctor = Klinika.Roles.Doctor;
using Klinika.Services;
using Klinika.Models;
using Klinika.Utilities;

namespace Klinika.GUI.Patient
{
    public partial class SearchDoctors : Form
    {
        internal Main parent;
        internal Roles.Patient patient { get { return parent.patient; } }
        RDoctor.Filters selectedDoctorFilter = RDoctor.Filters.BY_NAME;
        public SearchDoctors(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            DoctorNameRadioButton.Checked = true;
            UIUtilities.FillSpecializationComboBox(DoctorSpecializationComboBox, 0);
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
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
                RDoctor.Filters.BY_NAME => DoctorService.SearchByName(DoctorNameTextBox.Text),
                RDoctor.Filters.BY_SURNAME => DoctorService.SearchBySurname(DoctorSurnameTextBox.Text),
                RDoctor.Filters.BY_SPECIALIZATION => DoctorService.SearchBySpecialization(GetSelectedSpecializationID()),
                _ => new List<RDoctor>()
            };
            DoctorsTable.Fill(result);
        }
        private void DoctorsTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            NewAppointmentButton.Enabled = true;
        }
        private int GetSelectedSpecializationID()
        {
            return (DoctorSpecializationComboBox.SelectedItem as Specialization).id;
        }
    }
}

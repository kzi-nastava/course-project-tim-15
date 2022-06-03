using System.Data;
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
            Initialize();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void Initialize()
        {
            DoctorNameRadioButton.Checked = true;
            FillSpecializationsComboBox();
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
        private void FillDoctorsTable(List<RDoctor>? doctors = null)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Doctor ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Specialization");
            dataTable.Columns.Add("Grade");

            if (doctors == null) return;
            foreach (RDoctor doctor in doctors)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["Doctor ID"] = doctor.id;
                newRow["Name"] = doctor.name;
                newRow["Surname"] = doctor.surname;
                newRow["Specialization"] = doctor.specialization;
                newRow["Grade"] = string.Format("{0:0.00}", DoctorService.GetGrade(doctor.id));
                dataTable.Rows.Add(newRow);
            }

            DoctorsTable.DataSource = dataTable;
            DoctorsTable.ClearSelection();
            NewAppointmentButton.Enabled = false;
        }
        private void NewAppointmentButtonClick(object sender, EventArgs e)
        {
            var doctorID = Convert.ToInt32(UIUtilities.GetCellValue(DoctorsTable, "Doctor ID"));
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
            FillDoctorsTable(result);
        }
        private void DoctorsTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            NewAppointmentButton.Enabled = true;
        }
        private int GetSelectedSpecializationID()
        {
            return (DoctorSpecializationComboBox.SelectedItem as Specialization).id;
        }
        private void FillSpecializationsComboBox()
        {
            var specializations = SpecializationService.GetAll().ToArray();
            DoctorSpecializationComboBox.Items.AddRange(specializations);
            DoctorSpecializationComboBox.SelectedIndex = 0;
        }
    }
}

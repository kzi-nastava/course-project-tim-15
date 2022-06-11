using Klinika.Services;
using Klinika.Roles;
using Klinika.Utilities;
using System.Data;
using Klinika.Models;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Dependencies;

namespace Klinika.GUI.Patient
{
    public partial class NewAppointment : Form
    {
        private readonly DoctorScheduleService? scheduleService;
        internal Main parent;
        internal Roles.Patient patient { get { return parent.patient; } }
        public NewAppointment(Main parent)
        {
            InitializeComponent();
            scheduleService = StartUp.serviceProvider.GetService<DoctorScheduleService>();
            this.parent = parent;
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            Initialize();
            UIUtilities.FillDoctorComboBox(DoctorComboBox);
        }
        private void Initialize()
        {
            ScheduleButton.Enabled = false;
            OccupiedAppointmentsTable.DataSource = new DataTable();
        }
        private void FindAppointmentsButtonClick(object sender, EventArgs e)
        {
            if (!IsDateValid(AppointmentDatePicker.Value)) return;

            int doctorID = (DoctorComboBox.SelectedItem as User).id;
            OccupiedAppointmentsTable.Fill(scheduleService.GetAppointments(AppointmentDatePicker.Value, doctorID));
            ScheduleButton.Enabled = true;
        }
        private void ScheduleButtonClick(object sender, EventArgs e)
        {
            var doctor = (DoctorComboBox.SelectedItem as User);
            var appointment = new Appointment(doctor.id, patient.id, AppointmentDatePicker.Value);
            var dto = new PersonalAppointmentDTO(this, appointment, true, true, OccupiedAppointmentsTable);
            new PersonalAppointment(dto).Show();
        }
        private void RecommendButtonClick(object sender, EventArgs e)
        {
            new AppointmentRecommendation(this).Show();
        }
        public bool IsDateValid(DateTime dateTime)
        {
            if (dateTime > DateTime.Now) return true;
            MessageBoxUtilities.ShowErrorMessage("Date is not valid!");
            return false;
        }
    }
}

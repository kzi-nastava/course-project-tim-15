using Klinika.Appointments.Models;
using Klinika.Appointments.Services;
using Klinika.Core.Dependencies;
using Klinika.Core.Utilities;
using Klinika.Requests.Models;
using Klinika.Requests.Services;
using Klinika.Schedule.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Patient
{
    public partial class ViewSchedule : Form
    {
        private readonly PatientRequestService? patientRequestService;
        private readonly AppointmentService? appointmentService;
        private readonly ScheduleService? scheduleService;
        internal Main parent;
        internal Users.Models.Patient patient { get { return parent.patient; } }
        public ViewSchedule(Main parent)
        {
            InitializeComponent();
            patientRequestService = StartUp.serviceProvider.GetService<PatientRequestService>();
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
            scheduleService = StartUp.serviceProvider.GetService<ScheduleService>();
            this.parent = parent;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            Initialize();
        }
        private void ClosingForm(object sender, FormClosingEventArgs e) => parent.Enabled = true;
        private void Initialize()
        {
            
            PersonalAppointmentsTable.Fill(scheduleService.GetAll(patient));
            ModifyButton.Enabled = false;
            DeleteButton.Enabled = false;
        }
        private void ModifyButtonClick(object sender, EventArgs e)
        {
            var dto = new PersonalAppointmentDTO(this, PersonalAppointmentsTable.GetSelected(), false, false, PersonalAppointmentsTable);
            new PersonalAppointment(dto).Show();
        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (!UIUtilities.Confirm("Are you sure you want to delete selected appointment?")) return;

            Appointment selected = PersonalAppointmentsTable.GetSelected();
            bool needApproval = DateTime.Now.AddDays(2).Date >= selected.dateTime.Date;

            if (needApproval && !UIUtilities.Confirm("Changes that you have requested have to be check by secretary. Do you want to send request?")) return;

            patientRequestService.Send(!needApproval, selected, PatientRequest.Types.DELETE);
            if (needApproval) return;

            appointmentService.Delete(selected.id);
            PersonalAppointmentsTable.DeleteSelected();
        }
        private void PersonalAppointmentsTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            ModifyButton.Enabled = true;
            DeleteButton.Enabled = true;
        }
    }
}

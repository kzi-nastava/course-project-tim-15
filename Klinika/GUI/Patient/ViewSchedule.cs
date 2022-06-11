using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Patient
{
    public partial class ViewSchedule : Form
    {
        internal Main parent;
        internal Roles.Patient patient { get { return parent.patient; } }
        public ViewSchedule(Main parent)
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
            PersonalAppointmentsTable.Fill(AppointmentRepository.GetAll(patient.id, User.RoleType.PATIENT));
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

            PatientRequestService.Send(!needApproval, selected, PatientRequest.Types.DELETE);
            if (needApproval) return;

            AppointmentService.Delete(selected.id);
            PersonalAppointmentsTable.DeleteSelected();
        }
        private void PersonalAppointmentsTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            ModifyButton.Enabled = true;
            DeleteButton.Enabled = true;
        }
    }
}

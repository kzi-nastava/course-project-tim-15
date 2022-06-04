using Klinika.Forms;

namespace Klinika.Models
{
    public class PersonalAppointmentDTO
    {
        internal Form parent { get; }
        internal Appointment? appointment { get; set; }
        internal bool isDatePicked { get; }
        internal bool isCreate { get; }
        internal AppointmentsDataGridView? appointmentsTable { get; }
        public PersonalAppointmentDTO(Form parent, Appointment appointment, bool isCreate, bool isDatePicked, AppointmentsDataGridView appointmentsTable = null)
        {
            this.parent = parent;
            this.appointment = appointment;
            this.isDatePicked = isDatePicked;
            this.isCreate = isCreate;
            this.appointmentsTable = appointmentsTable;
        }
        public void EnableParent()
        {
            parent.Enabled = true;
        }
        public void DisabledParent()
        {
            parent.Enabled = false;
        }
        public void InsertNewAppointmentInTable()
        {
            appointmentsTable.Insert(appointment);
        }
        public void ModifyAppointmentInTable()
        {
            appointmentsTable.ModifySelected(appointment);
        }
    }
}

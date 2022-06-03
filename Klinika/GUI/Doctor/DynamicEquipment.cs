using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Doctor
{
    public partial class DynamicEquipment : Form
    {
        internal readonly ViewSchedule parent;
        private readonly Appointment appointment;
        public DynamicEquipment(ViewSchedule parent, Appointment appointment)
        {
            InitializeComponent();
            this.parent = parent;
            this.appointment = appointment;
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            EquipmentTable.Fill(EquipmentService.GetDynamicEquipment(appointment.roomID));
        }
        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            CompleteAppointment();
            parent.Enabled = true;
        }
        private void EquipmentTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            SpentSpinner.Maximum = EquipmentTable.GetSelected().quantity;
            SpentSpinner.Value = EquipmentTable.GetSelected().spent;
            SpentSpinner.Enabled = true;
            ConfirmButton.Enabled = true;
        }
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            EquipmentTable.GetSelected().spent = Convert.ToInt32(SpentSpinner.Value);
            EquipmentTable.ModifySelected(EquipmentTable.GetSelected());
        }
        private void FinishButtonClick(object sender, EventArgs e)
        {
            if(!UIUtilities.Confirm("Are you sure you entered correct data and want to save it?")) return;
            EquipmentService.UpdateRoomsDynamicEquipment(appointment.roomID, EquipmentTable.GetAll());
            Close();
        }
        private void CompleteAppointment()
        {
            AppointmentService.Complete(appointment);
            parent.ScheduleTable.ModifySelected(appointment);
        }

    }
}

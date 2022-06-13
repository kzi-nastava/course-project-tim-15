using Klinika.Dependencies;
using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.GUI.Doctor
{
    public partial class DynamicEquipment : Form
    {
        private readonly EquipmentService? equipmentService;
        private readonly AppointmentService? appointmentService;
        internal readonly ViewSchedule parent;
        private readonly Appointment appointment;
        public DynamicEquipment(ViewSchedule parent, Appointment appointment)
        {
            InitializeComponent();
            this.parent = parent;
            this.appointment = appointment;
            equipmentService = StartUp.serviceProvider.GetService<EquipmentService>();
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
        }
        private void LoadForm(object sender, EventArgs e)
        {
            parent.Enabled = false;
            EquipmentTable.Fill(equipmentService.GetDynamicEquipment(appointment.roomID));
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
            equipmentService.UpdateRoomsDynamicEquipment(appointment.roomID, EquipmentTable.GetAll());
            Close();
        }
        private void CompleteAppointment()
        {
            appointmentService.Complete(appointment);
            parent.ScheduleTable.ModifySelected(appointment);
        }

    }
}

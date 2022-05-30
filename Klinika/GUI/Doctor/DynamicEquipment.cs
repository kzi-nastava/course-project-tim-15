using Klinika.Models;
using Klinika.Services;
using Klinika.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Doctor
{
    public partial class DynamicEquipment : Form
    {
        internal readonly DoctorMain Parent;
        private readonly Appointment Appointment;
        public DynamicEquipment(DoctorMain parent, Appointment appointment)
        {
            InitializeComponent();
            Parent = parent;
            Appointment = appointment;
        }
        private void DynamicEquipmentLoad(object sender, EventArgs e)
        {
            Parent.Enabled = false;
            EquipmentTable.Fill(EquipmentService.GetDynamicEquipment(Appointment.RoomID));
        }
        private void DynamicEquipmentFormClosing(object sender, FormClosingEventArgs e)
        {
            CompleteAppointment();
            Parent.Enabled = true;
        }
        private void EquipmentTableCellClick(object sender, DataGridViewCellEventArgs e)
        {
            SpentSpinner.Maximum = EquipmentTable.GetSelected().Quantity;
            SpentSpinner.Value = EquipmentTable.GetSelected().Spent;
            SpentSpinner.Enabled = true;
            ConfirmButton.Enabled = true;
        }
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            EquipmentTable.GetSelected().Spent = Convert.ToInt32(SpentSpinner.Value);
            EquipmentTable.ModifySelected(EquipmentTable.GetSelected());
        }
        private void FinishButtonClick(object sender, EventArgs e)
        {
            if(!UIUtilities.Confirm("Are you sure you entered correct data and want to save it?")) return;
            EquipmentService.UpdateRoomsDynamicEquipment(Appointment.RoomID, EquipmentTable.GetAll());
            Close();
        }
        private void CompleteAppointment()
        {
            AppointmentService.Complete(Appointment);
            Parent.ScheduleTable.ModifySelected(Appointment);
        }

    }
}

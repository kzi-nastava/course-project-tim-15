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

        private void CompleteAppointment()
        {
            //AppointmentService.Complete(Appointment);
            //Parent.ScheduleTable.ModifySelected(Appointment);
        }
    }
}

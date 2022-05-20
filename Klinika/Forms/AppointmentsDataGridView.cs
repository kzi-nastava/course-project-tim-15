using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Forms
{
    public class AppointmentsDataGridView : DataGridView
    {
        private List<Appointment> Appointments;
        public AppointmentsDataGridView() : base()
        {
            Appointments = new List<Appointment>();
        }
    }
}

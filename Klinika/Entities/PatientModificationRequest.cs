using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Entities
{
    internal class PatientModificationRequest
    {
        public int oldDoctorID { get; set; }
        public int newDoctorID { get; set; }
        public DateTime oldAppointment { get; set; }
        public DateTime newAppointment { get; set; }
        public string changesMadeDescription { get; set; }


        public PatientModificationRequest(int doctorID,DateTime oldAppointment,string changesMadeDescription)
        {
            this.oldDoctorID = doctorID;
            this.oldAppointment = oldAppointment;
            this.changesMadeDescription = changesMadeDescription;
            string[] tokens = changesMadeDescription.Split(';');
            newAppointment = DateTime.Parse(tokens[0].Split('=')[1]);
            newDoctorID = Convert.ToInt32(tokens[1].Split('=')[1]);
        }


    }
}

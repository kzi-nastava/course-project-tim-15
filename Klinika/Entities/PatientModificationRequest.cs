using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Entities
{
    internal class PatientModificationRequest
    {
        int doctorID { get; set; }

        DateTime appointment { get; set; }
        string changesMadeDescription { get; set; }

        public PatientModificationRequest(int doctorID,DateTime appointment,string changesMadeDescription)
        {
            this.doctorID = doctorID;
            this.appointment = appointment;
            this.changesMadeDescription = changesMadeDescription;
        }

    }
}

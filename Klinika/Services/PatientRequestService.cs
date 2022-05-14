using Klinika.Models;
using Klinika.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    public class PatientRequestService
    {
        public static void SendDeleted(bool isApproved, Appointment toDelete)
        {
            PatientRequest patientRequest = new PatientRequest(-1, toDelete.PatientID, toDelete.ID,
                        'D', GenerateDescription(toDelete.DateTime, toDelete.DoctorID), isApproved);
            PatientRequestRepository.Create(patientRequest);
        }
        public static string GenerateDescription(DateTime dateTime, int doctorID)
        {
            return "DateTime=" + dateTime.ToString("yyyy-MM-dd HH:mm:ss.000") + ";DoctorID=" + doctorID.ToString();
        }
    }
}

using Klinika.Models;
using Klinika.Repositories;
using System.Data;

namespace Klinika.Services
{
    internal class PatientRequestService
    {
        public static void Send(bool isApproved, Appointment appointment, PatientRequest.Types type)
        {
            PatientRequest patientRequest = new PatientRequest(appointment.patientID, appointment.id,
                        type, GenerateDescription(appointment), isApproved);
            PatientRequestRepository.Create(patientRequest);
        }
        public static PatientModificationRequest GetModificationRequest(int requestId)
        {
            return PatientRequestRepository.IdRequestPairs[requestId];
        }
        public static DataTable GetAll()
        {
            return PatientRequestRepository.GetAll();
        }
        public static void Approve(int requestId)
        {
            PatientRequestRepository.Approve(requestId);
        }
        public static void Deny(int requestId)
        {
            PatientRequestRepository.Deny(requestId);
        }

        private static string GenerateDescription(Appointment appointment)
        {
            return "DateTime=" + appointment.dateTime.ToString("yyyy-MM-dd HH:mm:ss.000")
                + ";DoctorID=" + appointment.doctorID.ToString();
        }
    }
}

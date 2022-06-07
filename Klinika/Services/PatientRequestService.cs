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

        public static List<PatientModificationRequest> GetAllModificationRequests()
        {
            List<PatientModificationRequest> modificationRequests = new List<PatientModificationRequest>();
            foreach (PatientRequest request in PatientRequestRepository.allRequests)
            {
                if (request.type == 'M')
                {
                    Appointment toModify = AppointmentService.GetById(request.medicalActionID);
                    modificationRequests.Add(new PatientModificationRequest(request.id,
                                                                            toModify.doctorID,
                                                                            toModify.dateTime,
                                                                            request.description
                                            ));
                }
            }
            return modificationRequests;
        }

        public static PatientModificationRequest GetModificationRequest(int requestId)
        {
            return GetAllModificationRequests().Where(x => x.requestID == requestId).First();
        }

        public static PatientRequest GetRequest(int requestId)
        {
            return PatientRequestRepository.allRequests.Where(x => x.id == requestId).First();
        }

        public static List<PatientRequest> GetAll()
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

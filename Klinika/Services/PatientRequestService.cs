using Klinika.Models;
using Klinika.Repositories;
using System.Data;
using Klinika.Interfaces;
using Klinika.Dependencies;
using Microsoft.Extensions.DependencyInjection;

namespace Klinika.Services
{
    internal class PatientRequestService
    {
        private readonly IPatientRequestRepo patientRequestRepo;
        private readonly AppointmentService appointmentService;

        public PatientRequestService(IPatientRequestRepo patientRequestRepo)
        {
            this.patientRequestRepo = patientRequestRepo;
            appointmentService = StartUp.serviceProvider.GetService<AppointmentService>();
        }

        public void Send(bool isApproved, Appointment appointment, PatientRequest.Types type)
        {
            PatientRequest patientRequest = new PatientRequest(appointment.patientID, appointment.id,
                        type, GenerateDescription(appointment), isApproved);
            patientRequestRepo.Create(patientRequest);
        }

        public List<PatientModificationRequest> GetAllModificationRequests()
        {
            List<PatientModificationRequest> modificationRequests = new List<PatientModificationRequest>();
            foreach (PatientRequest request in patientRequestRepo.GetAll())
            {
                if (request.type == 'M')
                {
                    Appointment toModify = appointmentService.GetById(request.medicalActionID);
                    modificationRequests.Add(new PatientModificationRequest(request.id,
                                                                            toModify.doctorID,
                                                                            toModify.dateTime,
                                                                            request.description
                                            ));
                }
            }
            return modificationRequests;
        }

        public PatientModificationRequest GetModificationRequest(int requestId)
        {
            return GetAllModificationRequests().Where(x => x.requestID == requestId).First();
        }

        public PatientRequest GetRequest(int requestId)
        {
            return patientRequestRepo.GetAll().Where(x => x.id == requestId).First();
        }

        public List<PatientRequest> GetAll()
        {
            return patientRequestRepo.GetAll();
        }

        public void Approve(int requestId)
        {
            patientRequestRepo.Approve(requestId);
        }

        public void Deny(int requestId)
        {
            patientRequestRepo.Deny(requestId);
        }

        private string GenerateDescription(Appointment appointment)
        {
            return "DateTime=" + appointment.dateTime.ToString("yyyy-MM-dd HH:mm:ss.000")
                + ";DoctorID=" + appointment.doctorID.ToString();
        }
    }
}

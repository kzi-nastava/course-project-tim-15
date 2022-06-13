using Klinika.Interfaces;
using Klinika.Models;

namespace Klinika.Services
{
    public class VacationRequestService
    {
        private readonly IVacationRequestRepo vacationRequestRepo;
        public VacationRequestService(IVacationRequestRepo vacationRequestRepo) => this.vacationRequestRepo = vacationRequestRepo;
        public List<VacationRequest> GetAll(int doctorID) => vacationRequestRepo.GetAll(doctorID);
        public void Create(VacationRequest vacationRequest) => vacationRequest.id = vacationRequestRepo.Create(vacationRequest);
        public static void Approve(VacationRequest request)
        {
            //vacationRequestRepo.Approve(request);
        }

        public static void Deny(VacationRequest request)
        {
            //vacationRequestRepo.Deny(request);
        }
    }
}

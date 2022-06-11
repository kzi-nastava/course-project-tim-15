using Klinika.Interfaces;
using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    public class VacationRequestService
    {
        private readonly IVacationRequestRepo vacationRequestRepo;
        public VacationRequestService() => vacationRequestRepo = new VacationRequestRepository();
        public List<VacationRequest> GetAll(int doctorID) => vacationRequestRepo.GetAll(doctorID);
        public void Create(VacationRequest vacationRequest) => vacationRequest.id = vacationRequestRepo.Create(vacationRequest);
    }
}

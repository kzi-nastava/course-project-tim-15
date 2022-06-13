using Klinika.Interfaces;
using Klinika.Models;

namespace Klinika.Services
{
    public class VacationRequestService
    {
        private readonly IVacationRequestRepo vacationRequestRepo;
        public VacationRequestService(IVacationRequestRepo vacationRequestRepo) => this.vacationRequestRepo = vacationRequestRepo;
        public List<VacationRequest> GetAll(int doctorID) => vacationRequestRepo.GetAll(doctorID);
        public List<VacationRequest> GetAll() => vacationRequestRepo.GetAll();
        public void Create(VacationRequest vacationRequest) => vacationRequest.id = vacationRequestRepo.Create(vacationRequest);
        public void Approve(VacationRequest request)
        {
            vacationRequestRepo.Approve(request);
        }
        public void Deny(VacationRequest request)
        {
            vacationRequestRepo.Deny(request);
        }
    }
}

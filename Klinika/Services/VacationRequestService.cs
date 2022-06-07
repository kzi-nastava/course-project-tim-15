using Klinika.Interfaces;
using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    public class VacationRequestService
    {
        private readonly IVacationRequestRepo vacationRequestRepo;
        public VacationRequestService()
        {
            vacationRequestRepo = new VacationRequestRepository();
        }
        public List<VacationRequest> GetAll(int doctorID)
        {
            return vacationRequestRepo.GetAll(doctorID);
        }
        public  void Create(VacationRequest vacationRequest)
        {
            vacationRequest.id = vacationRequestRepo.Create(vacationRequest);
        }
        public bool IsOnVacation(DateTime start, int doctorID)
        {
            List<VacationRequest> forSelectedTimeSpan = vacationRequestRepo.GetAll(doctorID).Where(
                x => x.fromDate < start && x.toDate > start && x.status != (char)VacationRequest.Statuses.DENIED).ToList();
            
            if (forSelectedTimeSpan.Count == 0) return false;
            return true;
        }
    }
}

using Klinika.Models;
using Klinika.Repositories;

namespace Klinika.Services
{
    public class VacationRequestService
    {
        public static List<VacationRequest> GetAll(int doctorID)
        {
            return VacationRequestRepository.GetAll(doctorID);
        }

        public static List<VacationRequest> GetAll()
        {
            return VacationRequestRepository.GetAll();
        }
        public static void Create(VacationRequest vacationRequest)
        {
            vacationRequest.id = VacationRequestRepository.Create(vacationRequest);
        }
        public static bool IsOnVacation(DateTime start, int doctorID)
        {
            List<VacationRequest> forSelectedTimeSpan = VacationRequestRepository.GetAll(doctorID).Where(
                x => x.fromDate < start && x.toDate > start && x.status != (char)VacationRequest.Statuses.DENIED).ToList();
            
            if (forSelectedTimeSpan.Count == 0) return false;
            return true;
        }

        public static void Approve(VacationRequest request)
        {
            VacationRequestRepository.Approve(request);
        }

        public static void Deny(VacationRequest request)
        {
            VacationRequestRepository.Deny(request);
        }
    }
}

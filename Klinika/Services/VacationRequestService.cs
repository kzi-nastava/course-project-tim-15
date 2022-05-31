using Klinika.Models;
using Klinika.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    public class VacationRequestService
    {
        public static List<VacationRequest> GetAll(int doctorID)
        {
            return VacationRequestRepository.GetAll(doctorID);
        }
        public static void Create(VacationRequest vacationRequest)
        {
            vacationRequest.ID = VacationRequestRepository.Create(vacationRequest);
        }
        public static bool IsOnVacation(DateTime start, int doctorID)
        {
            List<VacationRequest> forSelectedTimeSpan = VacationRequestRepository.GetAll(doctorID).Where(
                x => x.FromDate < start && x.ToDate > start && x.Status != (char)VacationRequest.Statuses.DENIED).ToList();
            
            if (forSelectedTimeSpan.Count == 0) return false;
            return true;
        }
    }
}

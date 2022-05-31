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
    }
}

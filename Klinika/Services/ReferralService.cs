using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class ReferralService
    {
        public static DataTable GetReferralsPerPatient(int patientId)
        {
            return ReferalRepository.GetReferralsPerPatient(patientId);
        }

        public static void MarkAsUsed(int referralId)
        {
            ReferalRepository.MarkAsUsed(referralId);
        }
    }
}

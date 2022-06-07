using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Interfaces
{
    public interface IReferralRepo
    {
        void Create(int _patientID, int _specializationID, int _doctorID);
    }
}

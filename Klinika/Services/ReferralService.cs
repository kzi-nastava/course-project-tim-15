using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Exceptions;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class ReferralService
    {
        public static void Validate(int doctorID, DateTime appointmentStart)
        {

            if (appointmentStart <= DateTime.Now)
            {
                throw new DateTimeInvalidException("Selected appointment time is incorrect!");
            }

            if (doctorID == -1)
            {
                throw new FieldEmptyException("Doctor is not selected!");
            }

            if (AppointmentRepository.GetInstance().IsOccupied(appointmentStart, 15, -1, doctorID))
            {
                throw new DoctorUnavailableException("The selected doctor is not available at the selected time!");
            }
        }
    }
}

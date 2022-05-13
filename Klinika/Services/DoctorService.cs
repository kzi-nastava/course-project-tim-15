using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Repositories;
using Klinika.Roles;
using Klinika.Models;

namespace Klinika.Services
{
    internal class DoctorService
    {
        public static Doctor? GetSuitable(int specializationId,TimeSlot slot)
        {
            List<Doctor> allDoctors = DoctorRepository.GetInstance().doctors; 
            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.specialization.ID == specializationId &&
                    !AppointmentRepository.GetInstance().IsOccupied(newAppointmentStart:slot.from,doctorID:doctor.ID))
                {
                    return doctor;
                }
            }
            return null;
        }
    }
}

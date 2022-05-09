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
        public static Doctor? GetSuitable(string specialization,DateTime from)
        {
            List<Doctor> allDoctors = DoctorRepository.GetAll();
            foreach (Doctor doctor in allDoctors)
            {
                
                if (doctor.specialization.Name.Equals(specialization) &&
                    !AppointmentRepository.GetInstance().IsOccupied(newAppointmentStart:from,doctorId:doctor.ID))
                {
                    return doctor;
                }
            }
            return null;
        }
    }
}

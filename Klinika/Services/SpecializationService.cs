using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using Klinika.Roles;
using Klinika.Repositories;


namespace Klinika.Services
{
    internal class SpecializationService
    {
        private DoctorRepository doctorRepository;

        public SpecializationService()
        {
            doctorRepository = DoctorRepository.GetInstance();
        }
        
        public List<Specialization> GetAllAvailableSpecializations()
        {
            List<int> availableSpecializationsIds = new List<int>();
            List<Specialization> available = new List<Specialization>();
            foreach (Doctor doctor in doctorRepository.doctors)
            {
                if (!availableSpecializationsIds.Contains(doctor.specialization.ID))
                {
                    availableSpecializationsIds.Add(doctor.specialization.ID);
                    available.Add(doctor.specialization);
                }
            }
            return available;
        }
    }
}

using Klinika.Models;
using Klinika.Roles;
using Klinika.Interfaces;

namespace Klinika.Services
{
    internal class SpecializationService
    {
        private readonly IDoctorRepo doctorRepo;

        public SpecializationService(IDoctorRepo doctorRepo) => this.doctorRepo = doctorRepo;
        public List<Specialization> GetAllAvailableSpecializations()
        {
            List<int> availableSpecializationsIds = new List<int>();
            List<Specialization> available = new List<Specialization>();
            foreach (Doctor doctor in doctorRepo.GetAll())
            {
                if (!availableSpecializationsIds.Contains(doctor.specialization.id))
                {
                    availableSpecializationsIds.Add(doctor.specialization.id);
                    available.Add(doctor.specialization);
                }
            }
            return available;
        }
        public List<Specialization> GetAll()
        {
            return doctorRepo.GetSpecializations();
        }
    }
}

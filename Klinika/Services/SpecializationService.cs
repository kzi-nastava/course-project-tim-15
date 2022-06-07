using Klinika.Models;
using Klinika.Repositories;
using Klinika.Roles;


namespace Klinika.Services
{
    internal class SpecializationService
    {        
        public static List<Specialization> GetAllAvailableSpecializations()
        {
            List<int> availableSpecializationsIds = new List<int>();
            List<Specialization> available = new List<Specialization>();
            foreach (Doctor doctor in DoctorRepository.GetInstance().doctors)
            {
                if (!availableSpecializationsIds.Contains(doctor.specialization.id))
                {
                    availableSpecializationsIds.Add(doctor.specialization.id);
                    available.Add(doctor.specialization);
                }
            }
            return available;
        }
        public static List<Specialization> GetAll()
        {
            return DoctorRepository.GetSpecializations();
        }
    }
}

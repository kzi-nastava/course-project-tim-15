using Klinika.Users.Interfaces;
using Klinika.Users.Models;

namespace Klinika.Users.Services
{
    internal class SpecializationService
    {
        private readonly IDoctorRepo doctorRepo;
        private readonly IUserRepo userRepo;

        public SpecializationService(IDoctorRepo doctorRepo, IUserRepo userRepo)
        {
            this.doctorRepo = doctorRepo;
            this.userRepo = userRepo;
        }
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
        public User[] GetSpecializedDoctors(int specializationID)
        {
            var doctorIDs = doctorRepo.GetSpecializedIDs(specializationID).ToArray();

            var specializedDoctors = new List<User>();
            foreach (int doctorID in doctorIDs)
            {
                var doctor = userRepo.GetSingle(doctorID);
                specializedDoctors.Add(doctor);
            }

            return specializedDoctors.ToArray();
        }
        public List<Specialization> GetAll()
        {
            return doctorRepo.GetSpecializations();
        }
    }
}

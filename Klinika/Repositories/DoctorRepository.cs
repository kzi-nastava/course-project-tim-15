using Klinika.Models;
using Klinika.Roles;
using System.Data;
using Klinika.Interfaces;

namespace Klinika.Repositories
{
    internal class DoctorRepository : Repository, IDoctorRepo, IBaseDoctorRepo
    {
        public  List<Doctor> doctors { get; }
        private readonly IUserRepo userRepo;

        private DoctorRepository()
        {
            doctors = GetAll();
            userRepo = new UserRepository();
        }

        public List<Specialization> GetSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();
            
            string getQuery = "SELECT * FROM [Specialization]";

            var resoult = database.ExecuteSelectCommand(getQuery);
            foreach(object row in resoult)
            {
                specializations.Add(new Specialization
                {
                    id = Convert.ToInt32(((object[])row)[0].ToString()),
                    name = ((object[])row)[1].ToString()
                });
            }

            return specializations;
        }

        private List<int> GetSpecializedIDs(int specializationID)
        {
            List<int> doctors = new List<int>();

            string getQuery = "SELECT UserID " +
                "FROM [DoctorSpecialization] " +
                "WHERE SpecializationID = @SpecializationID";

            var resoult = database.ExecuteSelectCommand(getQuery, ("SpecializationID", specializationID));
            foreach(object row in resoult)
            {
                doctors.Add(Convert.ToInt32(((object[])row)[0].ToString()));
            }

            return doctors;
        }

        public User[] GetSpecializedDoctors(int specializationID)
        {
            var doctorIDs = GetSpecializedIDs(specializationID).ToArray();

            var specializedDoctors = new List<User>();
            foreach (int doctorID in doctorIDs)
            {
                var doctor = userRepo.Users.FirstOrDefault(x => x.id == doctorID);
                specializedDoctors.Add(doctor);
            }

            return specializedDoctors.ToArray();
        }

        public Specialization GetSpecialization (int doctorID)
        {
            string getSpecializationQuerry = "SELECT [Specialization].ID, [Specialization].Name " +
                                          "FROM [Specialization] JOIN [DoctorSpecialization] " +
                                          "ON [Specialization].ID = [DoctorSpecialization].SpecializationID " +
                                          $"WHERE [DoctorSpecialization].UserID = {doctorID}";

            var selection = database.ExecuteSelectCommand(getSpecializationQuerry);
            Specialization specialization = new Specialization
            {
                id = Convert.ToInt32(((object[])selection[0])[0]),
                name = ((object[])selection[0])[1].ToString()
            };

            return specialization;
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            string getAllQuery = "SELECT [DoctorSpecialization].UserID, [User].Name,[User].Surname, " +
                                 "[DoctorSpecialization].SpecializationID, [DoctorSpecialization].OfficeID, [Specialization].Name 'Specialization' " +
                                 "FROM [DoctorSpecialization] " +
                                 "LEFT OUTER JOIN [User] ON [DoctorSpecialization].UserID = [User].ID " +
                                 "LEFT OUTER JOIN [Specialization] ON [DoctorSpecialization].SpecializationID = [Specialization].ID";

            DataTable allDoctors = database.CreateTableOfData(getAllQuery);

            foreach(DataRow row in allDoctors.Rows)
            {
                Specialization specialization = new Specialization(
                                                Convert.ToInt32(row["SpecializationID"]),
                                                row["Specialization"].ToString());

                Doctor doctor = new Doctor(
                                Convert.ToInt32(row["UserID"]),
                                row["Name"].ToString(),
                                row["Surname"].ToString(),
                                specialization,
                                Convert.ToInt32(row["OfficeID"]));
                doctors.Add(doctor);
            }

            return doctors;
        }

    }
}

using Klinika.Data;
using Klinika.Models;
using Klinika.Roles;
using System.Data;
using System.Data.SqlClient;

namespace Klinika.Repositories
{
    internal class DoctorRepository : Repository
    {
        private static DoctorRepository? instance;
        public  List<Doctor> doctors { get; }

        private DoctorRepository()
        {
            doctors = GetAll();
        }

        public static DoctorRepository GetInstance()
        {
            if (instance == null) instance = new DoctorRepository();
            return instance;
        }

        public static List<Specialization> GetSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();
            
            string getQuery = "SELECT * FROM [Specialization]";

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getQuery);
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

        private static List<int> GetSpecializedIDs(int specializationID)
        {
            List<int> doctors = new List<int>();

            SqlConnection database = DatabaseConnection.GetInstance().database;
            string getQuery = "SELECT UserID " +
                "FROM [DoctorSpecialization] " +
                "WHERE SpecializationID = @SpecializationID";

            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getQuery, ("SpecializationID", specializationID));
            foreach(object row in resoult)
            {
                doctors.Add(Convert.ToInt32(((object[])row)[0].ToString()));
            }

            return doctors;
        }

        public static User[] GetSpecializedDoctors(int specializationID)
        {
            var doctorIDs = GetSpecializedIDs(specializationID).ToArray();

            var specializedDoctors = new List<User>();
            foreach (int doctorID in doctorIDs)
            {
                var doctor = UserRepository.GetInstance().Users.FirstOrDefault(x => x.ID == doctorID);
                specializedDoctors.Add(doctor);
            }

            return specializedDoctors.ToArray();
        }

        public static Specialization GetSpecialization (int DoctorID)
        {
            string getSpecializationQuerry = "SELECT [Specialization].ID, [Specialization].Name " +
                                          "FROM [Specialization] JOIN [DoctorSpecialization] " +
                                          "ON [Specialization].ID = [DoctorSpecialization].SpecializationID " +
                                          $"WHERE [DoctorSpecialization].UserID = {DoctorID}";

            var selection = DatabaseConnection.GetInstance().ExecuteSelectCommand(getSpecializationQuerry);
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

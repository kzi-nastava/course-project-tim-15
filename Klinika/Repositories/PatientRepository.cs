using Klinika.Data;
using System.Data;
using System.Data.SqlClient;
using Klinika.Roles;

namespace Klinika.Repositories
{
    internal class PatientRepository : Repository
    {
        public static Dictionary<string, int>? EmailIDPairs { get; private set; }
        public static Dictionary<int,Patient>? IDPatientPairs { get; private set; }

        public static DataTable GetAll()
        {
            EmailIDPairs = new Dictionary<string, int>();
            IDPatientPairs = new Dictionary<int,Patient>();

            string getAllQuery = "SELECT ID, JMBG, Name, Surname, Birthdate, Gender, Email, Password, IsBlocked as Blocked, WhoBlocked as BlockedBy " +
                                      "FROM [User] " +
                                      "WHERE UserType = 1 AND IsDeleted = 0";

            DataTable retrievedPatients = DatabaseConnection.GetInstance().CreateTableOfData(getAllQuery);
            foreach (DataRow patient in retrievedPatients.Rows)
            {
                int id = Convert.ToInt32(patient["ID"]);
                string email = patient["Email"].ToString();
                    
                Patient newPatient = new Patient(id,
                                                patient["JMBG"].ToString(),
                                                patient["Name"].ToString(),
                                                patient["Surname"].ToString(),
                                                DateTime.Parse(patient["Birthdate"].ToString()),
                                                patient["Gender"].ToString()[0],
                                                email,
                                                patient["Password"].ToString());

                EmailIDPairs.Add(email, id);
                IDPatientPairs.Add(id, newPatient);

            }
                retrievedPatients.Columns.Remove("Password");

            return retrievedPatients;

        }

        internal static void Modify(Patient patient)
        {
            string modifyQuery = "UPDATE [User] " +
                                 "SET JMBG = @JMBG, " +
                                 "Name = @Name, " +
                                 "Surname = @Surname, " +
                                 "Birthdate = @Birthdate, " +
                                 "Gender = @Gender, " +
                                 "Password = @Password " +
                                 "WHERE ID = @ID";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(modifyQuery,
            ("@ID", patient.ID),
            ("@JMBG", patient.jmbg),
            ("@Name", patient.Name),
            ("@Surname", patient.Surname),
            ("@Birthdate", patient.birthdate.Date),
            ("@Gender", patient.gender),
            ("@Password", patient.Password)
            ); 
        }

        //Logical deletion
        public static void Delete(int id)
        {
            string deleteQuery = "UPDATE [User] SET IsDeleted = 1 WHERE ID = @ID";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(deleteQuery, ("@ID", id));
            if (EmailIDPairs != null)
            {
                
                EmailIDPairs.Remove(IDPatientPairs[id].Email);
            }
        }

        public static void Create(Patient newPatient)
        {
            string createQuery = "INSERT INTO [User] " +
                "(JMBG,Name,Surname,Birthdate,Gender,Email,Password,UserType) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@JMBG,@Name,@Surname,@Birthdate,@Gender,@Email,@Password,@UserType)";

            int createdID = (int)DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(
                createQuery,
                ("@JMBG", newPatient.jmbg),
                ("@Name", newPatient.Name),
                ("@Surname", newPatient.Surname),
                ("@Birthdate", newPatient.birthdate.Date),
                ("@Gender", newPatient.gender),
                ("@Email", newPatient.Email),
                ("@Password", newPatient.Password),
                ("@UserType", 1)
                );
            
            MedicalRecordRepository.Create(createdID);

            if (EmailIDPairs != null)
            {
                EmailIDPairs.Add(newPatient.Email, createdID);
            }
        }

        public static void Block(int id)
        {
            string blockQuery = "UPDATE [User] SET IsBlocked = 1, WhoBlocked = 'SEC' " +
                                "WHERE ID = @ID";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(blockQuery, ("@ID", id));

        }

        public static void Unblock(int id)
        {
            string unblockQuery = "UPDATE [User] SET IsBlocked = 0, WhoBlocked = NULL " +
                                "WHERE ID = @ID";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(unblockQuery, ("@ID", id));
        }
    }

}

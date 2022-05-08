using Klinika.Data;
using System.Data;
using System.Data.SqlClient;
using Klinika.Roles;

namespace Klinika.Repositories
{
    internal class PatientRepository
    {
        public static Dictionary<string, int>? EmailIDPairs { get; set; }
        public static Dictionary<int,Patient> IDPatientPairs { get; set; }
        public static DataTable GetAll()
        {
            EmailIDPairs = new Dictionary<string, int>();
            IDPatientPairs = new Dictionary<int,Patient>();
            DataTable? retrievedPatients = null;
            string getAllQuery = "SELECT ID, JMBG, Name, Surname, Birthdate, Gender, Email, Password, IsBlocked as Blocked, WhoBlocked as BlockedBy " +
                                      "FROM [User] " +
                                      "WHERE UserType = 1 AND IsDeleted = 0";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuery, DatabaseConnection.GetInstance().database);
                retrievedPatients = new DataTable();
                adapter.Fill(retrievedPatients);
                foreach (DataRow patient in retrievedPatients.Rows)
                {
                    int id = Convert.ToInt32(patient["ID"]);
                    string email = patient["Email"].ToString();
                    string jmbg = patient["JMBG"].ToString();
                    string name = patient["Name"].ToString();
                    string surname = patient["Surname"].ToString();
                    DateTime birthdate = DateTime.Parse(patient["Birthdate"].ToString());
                    char gender = patient["Gender"].ToString()[0];
                    string password = patient["Password"].ToString();

                    EmailIDPairs.Add(email, id);

                    Patient newPatient = new Patient(id, jmbg, name, surname, birthdate, gender, email, password);
                    IDPatientPairs.Add(id, newPatient);

                }
                retrievedPatients.Columns.Remove("ID");
                retrievedPatients.Columns.Remove("Password");
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return retrievedPatients;

        }

        internal static void Modify(int id,
                                    string jmbg,
                                    string name,
                                    string surname,
                                    DateTime birthdate,
                                    char gender,
                                    string email,
                                    string password)
        {
            string modifyQuery = "UPDATE [User] " +
                                 "SET JMBG = @JMBG, " +
                                 "Name = @Name, " +
                                 "Surname = @Surname, " +
                                 "Birthdate = @Birthdate, " +
                                 "Gender = @Gender, " +
                                 "Password = @Password " +
                                 "WHERE ID = @ID";

            SqlCommand modify = new SqlCommand(modifyQuery, DatabaseConnection.GetInstance().database);
            modify.Parameters.AddWithValue("@ID", id);
            modify.Parameters.AddWithValue("@JMBG", jmbg);
            modify.Parameters.AddWithValue("@Name", name);
            modify.Parameters.AddWithValue("@Surname", surname);
            modify.Parameters.AddWithValue("@Birthdate", birthdate.Date);
            modify.Parameters.AddWithValue("@Gender", gender);
            modify.Parameters.AddWithValue("@Password", password);
            try
            {
                SqlConnection database = DatabaseConnection.GetInstance().database;
                database.Open();
                modify.ExecuteNonQuery();
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }


        //Logical deletion
        public static void Delete(int id, string email)
        {
            string deleteQuery = "UPDATE [User] SET IsDeleted = 1 WHERE ID = @ID";
            try
            {
                SqlCommand delete = new SqlCommand(deleteQuery, DatabaseConnection.GetInstance().database);
                delete.Parameters.AddWithValue("@ID", id);
                DatabaseConnection.GetInstance().database.Open();
                delete.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
                if (EmailIDPairs != null)
                {
                    EmailIDPairs.Remove(email);
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void Create(string jmbg,
                                  string name,
                                  string surname,
                                  DateTime birthdate,
                                  char gender,
                                  string email,
                                  string password)
        {
            string createQuery = "INSERT INTO [User] " +
                "(JMBG,Name,Surname,Birthdate,Gender,Email,Password,UserType) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@JMBG,@Name,@Surname,@Birthdate,@Gender,@Email,@Password,@UserType)";
            SqlCommand create = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
            create.Parameters.AddWithValue("@JMBG", jmbg);
            create.Parameters.AddWithValue("@Name", name);
            create.Parameters.AddWithValue("@Surname", surname);
            create.Parameters.AddWithValue("@Birthdate", birthdate.Date);
            create.Parameters.AddWithValue("@Gender", gender);
            create.Parameters.AddWithValue("@Email", email);
            create.Parameters.AddWithValue("@Password", password);
            create.Parameters.AddWithValue("@UserType", 1);
            try
            {
                SqlConnection database = DatabaseConnection.GetInstance().database;
                database.Open();
                int createdID = (int)create.ExecuteScalar();
                string createMedicalRecordQuery = "INSERT INTO [Patient] (UserID) VALUES (@ID)";
                SqlCommand createMedicalRecord = new SqlCommand(createMedicalRecordQuery, database);
                createMedicalRecord.Parameters.AddWithValue("@ID", createdID);
                createMedicalRecord.ExecuteNonQuery();
                database.Close();
                if (EmailIDPairs != null)
                {
                    EmailIDPairs.Add(email, createdID);
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }


        public static (int id, string jmbg, string name, string surname, DateTime birthdate, char gender, string password)
        GetSingle(string email)
        {
            SqlConnection database = DatabaseConnection.GetInstance().database;
            string getSingleQuery = "SELECT ID, JMBG, Name, Surname, Birthdate, Gender, Password " +
                                     "FROM [User] " +
                                     "WHERE Email = @Email";
            int id = 0;
            string jmbg = "";
            string name = "";
            string surname = "";
            DateTime birthdate = DateTime.Now;
            char gender = 'x';
            string password = "";
            try
            {
                SqlCommand getSingle = new SqlCommand(getSingleQuery, database);
                getSingle.Parameters.AddWithValue("@Email", email);
                database.Open();
                using (SqlDataReader patient = getSingle.ExecuteReader())
                {
                    if (patient.Read())
                    {
                        id = Convert.ToInt32(patient["ID"]);
                        jmbg = patient["JMBG"].ToString();
                        name = patient["Name"].ToString();
                        surname = patient["Surname"].ToString();
                        birthdate = DateTime.Parse(patient["Birthdate"].ToString());
                        gender = patient["Gender"].ToString()[0];
                        password = patient["Password"].ToString();
                    }
                }
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return (id, jmbg, name, surname, birthdate, gender, password);

        }


        public static void Block(int id)
        {
            string blockQuery = "UPDATE [User] SET IsBlocked = 1, WhoBlocked = 'SEC' " +
                                "WHERE ID = @ID";
            SqlConnection database = DatabaseConnection.GetInstance().database;
            try
            {
                SqlCommand block = new SqlCommand(blockQuery, database);
                block.Parameters.AddWithValue("@ID", id);
                database.Open();
                block.ExecuteNonQuery();
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }


        public static void Unblock(int id)
        {
            string blockQuery = "UPDATE [User] SET IsBlocked = 0, WhoBlocked = NULL " +
                                "WHERE ID = @ID";
            SqlConnection database = DatabaseConnection.GetInstance().database;
            try
            {
                SqlCommand block = new SqlCommand(blockQuery, database);
                block.Parameters.AddWithValue("@ID", id);
                database.Open();
                block.ExecuteNonQuery();
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}

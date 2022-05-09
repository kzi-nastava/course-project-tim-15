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

        private static SqlConnection database = DatabaseConnection.GetInstance().database;

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
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuery, database);
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

            SqlCommand modify = new SqlCommand(modifyQuery, database);
            modify.Parameters.AddWithValue("@ID", patient.ID);
            modify.Parameters.AddWithValue("@JMBG", patient.jmbg);
            modify.Parameters.AddWithValue("@Name", patient.Name);
            modify.Parameters.AddWithValue("@Surname", patient.Surname);
            modify.Parameters.AddWithValue("@Birthdate", patient.birthdate.Date);
            modify.Parameters.AddWithValue("@Gender", patient.gender);
            modify.Parameters.AddWithValue("@Password", patient.Password);
            try
            {
                database.Open();
                modify.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                database.Close();
            }
        }


        //Logical deletion
        public static void Delete(int id, string email)
        {
            string deleteQuery = "UPDATE [User] SET IsDeleted = 1 WHERE ID = @ID";
            try
            {
                SqlCommand delete = new SqlCommand(deleteQuery, database);
                delete.Parameters.AddWithValue("@ID", id);
                database.Open();
                delete.ExecuteNonQuery();

                if (EmailIDPairs != null)
                {
                    EmailIDPairs.Remove(email);
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                database.Close();
            }
        }

        public static void Create(Patient newPatient)
        {
            string createQuery = "INSERT INTO [User] " +
                "(JMBG,Name,Surname,Birthdate,Gender,Email,Password,UserType) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@JMBG,@Name,@Surname,@Birthdate,@Gender,@Email,@Password,@UserType)";
            SqlCommand create = new SqlCommand(createQuery, database);
            
            create.Parameters.AddWithValue("@JMBG", newPatient.jmbg);
            create.Parameters.AddWithValue("@Name", newPatient.Name);
            create.Parameters.AddWithValue("@Surname", newPatient.Surname);
            create.Parameters.AddWithValue("@Birthdate", newPatient.birthdate.Date);
            create.Parameters.AddWithValue("@Gender", newPatient.gender);
            create.Parameters.AddWithValue("@Email", newPatient.Email);
            create.Parameters.AddWithValue("@Password", newPatient.Password);
            create.Parameters.AddWithValue("@UserType", 1);
            
            try
            {
                database.Open();
                int createdID = (int)create.ExecuteScalar();
                database.Close();
                MedicalRecordRepository.Create(createdID);

                if (EmailIDPairs != null)
                {
                    EmailIDPairs.Add(newPatient.Email, createdID);
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

        }


        public static Patient? GetSingle(string email)
        {

            string getSingleQuery = "SELECT ID, JMBG, Name, Surname, Birthdate, Gender, Password " +
                                     "FROM [User] " +
                                     "WHERE Email = @Email";
            Patient patient = null;
            try
            {
                SqlCommand getSingle = new SqlCommand(getSingleQuery, database);
                getSingle.Parameters.AddWithValue("@Email", email);
                database.Open();
                using (SqlDataReader retrieved = getSingle.ExecuteReader())
                {
                    if (retrieved.Read())
                    {
                        int id = Convert.ToInt32(retrieved["ID"]);
                        string jmbg = retrieved["JMBG"].ToString();
                        string name = retrieved["Name"].ToString();
                        string surname = retrieved["Surname"].ToString();
                        DateTime birthdate = DateTime.Parse(retrieved["Birthdate"].ToString());
                        char gender = retrieved["Gender"].ToString()[0];
                        string password = retrieved["Password"].ToString();
                        patient = new Patient(id,jmbg,name,surname,birthdate,gender,email,password);
                    }
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                database.Close();
            }

            return patient;

        }


        public static void Block(int id)
        {
            string blockQuery = "UPDATE [User] SET IsBlocked = 1, WhoBlocked = 'SEC' " +
                                "WHERE ID = @ID";
            try
            {
                SqlCommand block = new SqlCommand(blockQuery, database);
                block.Parameters.AddWithValue("@ID", id);
                database.Open();
                block.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                database.Close();
            }
        }


        public static void Unblock(int id)
        {
            string blockQuery = "UPDATE [User] SET IsBlocked = 0, WhoBlocked = NULL " +
                                "WHERE ID = @ID";
            try
            {
                SqlCommand block = new SqlCommand(blockQuery, database);
                block.Parameters.AddWithValue("@ID", id);
                database.Open();
                block.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                database.Close();
            }
        }
    }
}

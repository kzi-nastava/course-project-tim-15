using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Klinika.Data;
using Klinika.Exceptions;
using Klinika.Repositories;

namespace Klinika.Services
{
    internal class PatientService
    {
        public static Dictionary<string, int> EmailIDPairs { get; set; }
        public static DataTable Read()
        {
            EmailIDPairs = new Dictionary<string, int>();
            DataTable retrievedPatients = null;
            string getPatientsQuery = "SELECT ID, JMBG, Name, Surname, Birthdate, Gender, Email " +
                                      "FROM [User] " +
                                      "WHERE UserType = 1 AND IsDeleted = 0";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(getPatientsQuery, SQLConnection.GetInstance().databaseConnection);
                retrievedPatients = new DataTable();
                adapter.Fill(retrievedPatients);
                foreach (DataRow patient in retrievedPatients.Rows)
                {
                    EmailIDPairs.Add(patient["Email"].ToString(), Convert.ToInt32(patient["ID"]));
                }
                retrievedPatients.Columns.Remove("ID");
                return retrievedPatients;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return retrievedPatients;

        }

        internal static void Modify(int id,string jmbg, string name, string surname, DateTime birthdate, char gender, string email, string password)
        {
            string modifyQuery = "UPDATE [User] " +
                                 "SET JMBG = @JMBG, " +
                                 "Name = @Name, " +
                                 "Surname = @Surname, " +
                                 "Birthdate = @Birthdate, " +
                                 "Gender = @Gender, " +
                                 "Password = @Password " +
                                 "WHERE ID = @ID";
            SqlCommand modify = new SqlCommand(modifyQuery, SQLConnection.GetInstance().databaseConnection);
            modify.Parameters.AddWithValue("@ID", id);
            modify.Parameters.AddWithValue("@JMBG", jmbg);
            modify.Parameters.AddWithValue("@Name", name);
            modify.Parameters.AddWithValue("@Surname", surname);
            modify.Parameters.AddWithValue("@Birthdate", birthdate.Date);
            modify.Parameters.AddWithValue("@Gender", gender);
            modify.Parameters.AddWithValue("@Password", password);
            try
            {
                SqlConnection database = SQLConnection.GetInstance().databaseConnection;
                database.Open();
                modify.ExecuteNonQuery();
                database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool IsValid(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + 
                             @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" +
                             @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static void Validate(string JMBG,
                                    string name,
                                    string surname,
                                    DateTime birthdate,
                                    string email,
                                    string password,
                                    bool isModification = false)
        {
            if (string.IsNullOrEmpty(JMBG))
            {
                throw new FieldEmptyException("JMBG left empty!");
            }

            else if (JMBG.Length != 13)
            {
                throw new JMBGFormatInvalidException("JMBG format is not valid!");
            }

            else if (string.IsNullOrEmpty(name))
            {
                throw new FieldEmptyException("Name left empty!");
            }

            else if (string.IsNullOrEmpty(surname))
            {
                throw new FieldEmptyException("Surname left empty!");
            }

            else if (birthdate > DateTime.Now)
            {
                throw new BirthdateInvalidException("Invalid birthdate!");
            }

            else if (string.IsNullOrEmpty(email) && !isModification)
            {
                throw new FieldEmptyException("Email left empty!");
            }

            else if (EmailIDPairs.ContainsKey(email) && !isModification)
            {
                throw new ExistingEmailException("Email already in use!");
            }

            else if (!IsValid(email) && !isModification)
            {
                throw new EmailFormatInvalidException("Incorrect email format!");
            }

            else if (string.IsNullOrEmpty(password))
            {
                throw new FieldEmptyException("Password left empty!");
            }
            else if (password.Length < 4)
            {
                throw new FieldEmptyException("Password is too short!");
            }

        }

        //Logical deletion
        public static void Delete(int ID,string email)
        {
            string deleteQuery = "UPDATE [User] SET IsDeleted = 1 WHERE ID = @ID";
            try
            {
                SqlCommand delete = new SqlCommand(deleteQuery, SQLConnection.GetInstance().databaseConnection);
                delete.Parameters.AddWithValue("@ID", ID);
                SQLConnection.GetInstance().databaseConnection.Open();
                delete.ExecuteNonQuery();
                SQLConnection.GetInstance().databaseConnection.Close();
                EmailIDPairs.Remove(email);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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
            string insertQuery = "INSERT INTO [User] " +
                "(JMBG,Name,Surname,Birthdate,Gender,Email,Password,UserType) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@JMBG,@Name,@Surname,@Birthdate,@Gender,@Email,@Password,@UserType)";
            SqlCommand insert = new SqlCommand(insertQuery,SQLConnection.GetInstance().databaseConnection);
            insert.Parameters.AddWithValue("@JMBG", jmbg);
            insert.Parameters.AddWithValue("@Name", name);
            insert.Parameters.AddWithValue("@Surname", surname);
            insert.Parameters.AddWithValue("@Birthdate", birthdate.Date);
            insert.Parameters.AddWithValue("@Gender", gender);
            insert.Parameters.AddWithValue("@Email", email);
            insert.Parameters.AddWithValue("@Password", password);
            insert.Parameters.AddWithValue("@UserType", 1);
            try
            {
                SqlConnection database = SQLConnection.GetInstance().databaseConnection;
                database.Open();
                int insertedID = (int)insert.ExecuteScalar();
                string createMedicalRecordQuery = "INSERT INTO [Patient] (UserID) VALUES (@ID)";
                SqlCommand createMedicalRecord = new SqlCommand(createMedicalRecordQuery, database);
                createMedicalRecord.Parameters.AddWithValue("@ID", insertedID);
                createMedicalRecord.ExecuteNonQuery();
                database.Close();
                EmailIDPairs.Add(email, insertedID);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static (int id, string jmbg, string name, string surname, DateTime birthdate,char gender, string password)
        GetSingle(string email)
        {
            SqlConnection database = SQLConnection.GetInstance().databaseConnection;
            string getPatientQuery = "SELECT ID, JMBG, Name, Surname, Birthdate, Gender, Password " +
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
                SqlCommand getPatient = new SqlCommand(getPatientQuery, database);
                getPatient.Parameters.AddWithValue("@Email", email);
                database.Open();
                using(SqlDataReader reader = getPatient.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = Convert.ToInt32(reader["ID"]);
                        jmbg = reader["JMBG"].ToString();
                        name =  reader["Name"].ToString();
                        surname =  reader["Surname"].ToString();
                        birthdate =  DateTime.Parse(reader["Birthdate"].ToString());
                        gender =  reader["Gender"].ToString()[0];
                        password = reader["Password"].ToString();
                    }
                }
                database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return (id,jmbg,name,surname,birthdate,gender,password);

        }
    }
}

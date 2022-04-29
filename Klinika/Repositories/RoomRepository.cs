using Klinika.Data;
using System.Data;
using System.Data.SqlClient;

namespace Klinika.Repositories
{
    internal class RoomRepository
    {
        public static Dictionary<int, string>? types { get; set; }
        public static DataTable GetAll()
        {
            types = new Dictionary<int, string>();
            DataTable? retrievedRooms = null;
            DataTable? retrievedTypes = null;
            string getAllQuery = "SELECT [Room].ID, [RoomType].Name, [Room].Number " +
                                      "FROM [Room] " +
                                      "INNER JOIN [RoomType] ON [Room].Type = [RoomType].ID " +
                                      "WHERE IsDeleted = 0";
            string getAllTypes = "SELECT ID, Name " +
                                      "FROM [RoomType] ";
            try
            {
                SqlConnection database = DatabaseConnection.GetInstance().database;
                database.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuery, database);
                retrievedRooms = new DataTable();
                adapter.Fill(retrievedRooms);
                //retrievedPatients.Columns.Remove("ID");

                adapter = new SqlDataAdapter(getAllTypes, database);
                retrievedTypes = new DataTable();
                adapter.Fill(retrievedTypes);
                foreach(DataRow row in retrievedTypes.Rows)
                {
                    types.Add((int)row["ID"], row["Name"].ToString());
                }
                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return retrievedRooms;

        }

        public static void Create(int type, int number)
        {
            string createQuery = "INSERT INTO [Room] " +
                "(Type, Number) " +
                "VALUES (@Type,@Number)";
            SqlCommand create = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
            create.Parameters.AddWithValue("@Type", type);
            create.Parameters.AddWithValue("@Number", number);
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
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
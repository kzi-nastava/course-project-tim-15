using Klinika.Data;
using System.Data;
using System.Data.SqlClient;

namespace Klinika.Repositories
{
    internal class RoomRepository
    { 
        public static Dictionary<int, string>? types { get; set; }
        //returns type ID form Name
        public static int GetTypeId(string type)
        {
            return Repositories.RoomRepository.types.FirstOrDefault(x => x.Value == type).Key;
        }
        public static DataTable GetAll()
        {
            types = new Dictionary<int, string>();
            DataTable? retrievedRooms = null;
            DataTable? retrievedTypes = null;
            string getAllQuery = "SELECT [Room].ID, [RoomType].Name as Type, [Room].Number " +
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

        public static List<Models.RoomComboBoxItem> GetRooms()
        {
            List<Models.RoomComboBoxItem> rooms = new List<Models.RoomComboBoxItem>();
            DataTable? retrievedRooms = null;
            string getAllQuery = "SELECT [Room].ID, [Room].Number " +
                                      "FROM [Room] " +
                                      "WHERE IsDeleted = 0";
            try
            {
                SqlConnection database = DatabaseConnection.GetInstance().database;
                database.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuery, database);
                retrievedRooms = new DataTable();
                adapter.Fill(retrievedRooms);
                database.Close();

                foreach (DataRow row in retrievedRooms.Rows)
                {
                    rooms.Add(new Models.RoomComboBoxItem(row["Number"].ToString(), row["ID"].ToString()));
                }
                rooms = rooms.OrderBy(x => x.text).ToList();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            return rooms;
        }

        public static void Create(int type, int number)
        {
            string createQuery = "INSERT INTO [Room] " +
                "(Type, Number, IsDeleted) " +
                "VALUES (@Type, @Number, 0)";
            try
            {
                SqlCommand create = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
                create.Parameters.AddWithValue("@Type", type);
                create.Parameters.AddWithValue("@Number", number);
                DatabaseConnection.GetInstance().database.Open();
                create.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void Delete(int id)
        {
            string deleteQuery = "UPDATE [Room] SET IsDeleted = 1 WHERE ID = @ID";
            try
            {
                SqlCommand delete = new SqlCommand(deleteQuery, DatabaseConnection.GetInstance().database);
                delete.Parameters.AddWithValue("@ID", id);
                DatabaseConnection.GetInstance().database.Open();
                delete.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        internal static void Modify(int id, string type, int number)
        {
            string modifyQuery = "UPDATE [Room] " +
                                 "SET Type = @Type, " +
                                 "Number = @Number " +
                                 "WHERE ID = @ID";

            SqlCommand modify = new SqlCommand(modifyQuery, DatabaseConnection.GetInstance().database);
            modify.Parameters.AddWithValue("@ID", id);
            modify.Parameters.AddWithValue("@Type", GetTypeId(type));
            modify.Parameters.AddWithValue("@Number", number);
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
    }
}
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

        internal static void SimpleRenovate(Models.Renovation renovation)
        {
            string createQuery = "INSERT INTO [Renovations] " +
                "(RoomID, StartDate, EndDate, Advanced) " +
                "VALUES (@RoomID, @StartDate, @EndDate, @Advanced)";
            try
            {
                SqlCommand create = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
                create.Parameters.AddWithValue("@RoomID", renovation.id);
                create.Parameters.AddWithValue("@StartDate", renovation.from.ToString("yyyy-MM-dd"));
                create.Parameters.AddWithValue("@EndDate", renovation.to.ToString("yyyy-MM-dd"));
                create.Parameters.AddWithValue("@Advanced", renovation.advanced);
                DatabaseConnection.GetInstance().database.Open();
                create.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        internal static void SplitRenovation(Models.Renovation renovation, int renovationId)
        {
            string createQuery = "INSERT INTO [RenovationsAdvanced] " +
                "(ID, Type, FirstID, SecondID, SecondType, SecondNumber) " +
                "VALUES (@ID, @Type, @FirstID, @SecondID, @SecondType, @SecondNumber)";
            try
            {
                SqlCommand create = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
                create.Parameters.AddWithValue("@ID", renovationId);
                create.Parameters.AddWithValue("@Type", 1);
                create.Parameters.AddWithValue("@FirstID", renovation.id);
                create.Parameters.AddWithValue("@SecondID", 0);
                create.Parameters.AddWithValue("@SecondType", renovation.secondType);
                create.Parameters.AddWithValue("@SecondNumber", renovation.secondNumber);
                DatabaseConnection.GetInstance().database.Open();
                create.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        internal static int FindRenovation(Models.Renovation renovation)
        {
            int id = 0;
            DataTable? foundRenovation = null;
            string findQuery = "SELECT [Renovations].ID " +
                                      "FROM [Renovations] " +
                                      "WHERE RoomID = @RoomID AND StartDate = @StartDate AND EndDate = @EndDate";
            try
            {
                DatabaseConnection.GetInstance().database.Open();
                SqlCommand find = new SqlCommand(findQuery, DatabaseConnection.GetInstance().database);
                find.Parameters.AddWithValue("@RoomID", renovation.id.ToString());
                find.Parameters.AddWithValue("@StartDate", renovation.from.ToString("yyyy-MM-dd"));
                find.Parameters.AddWithValue("@EndDate", renovation.to.ToString("yyyy-MM-dd"));
                SqlDataReader reader = find.ExecuteReader();
                reader.Read();
                id = int.Parse(reader["ID"].ToString());
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return id;
        }

        internal static void AdvancedRenovation(Models.Renovation renovation)
        {
            SimpleRenovate(renovation);
            if(renovation.advanced == 1)
            {

            }
            else if(renovation.advanced == 2)
            {
                SplitRenovation(renovation, FindRenovation(renovation));
            }
        }

        public static bool Renovate(Models.Renovation renovation)
        {
            bool success = Services.RoomServices.DateValid(renovation);
            if (success)
            {
                if (renovation.advanced == 0)
                {
                    SimpleRenovate(renovation);
                }
                else
                {
                    AdvancedRenovation(renovation);
                }
            }
            return success;
        }
    }
}
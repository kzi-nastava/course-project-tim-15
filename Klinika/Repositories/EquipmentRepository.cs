using Klinika.Data;
using System.Data;
using System.Data.SqlClient;

namespace Klinika.Repositories
{
    internal class EquipmentRepository
    {
        public static DataTable GetAll()
        {
            DataTable? retrievedEquipment = null;
            string getAllQuery = "SELECT [Room].ID, [Room].Number, [RoomType].Name as 'Room Type', [Equipment].Name as Equipment, " +
                                 "[EquipmentType].Name as 'Equipment Type', [RoomEquipment].Quantity " +
                                 "FROM [RoomEquipment], [Room], [Equipment], [EquipmentType], [RoomType] " +
                                 "WHERE [RoomEquipment].RoomID = [Room].ID AND [RoomEquipment].EquipmentID = [Equipment].ID " +
                                 "AND [Equipment].TypeID = [EquipmentType].ID AND [Room].Type = [RoomType].ID";
            try
            {
                SqlConnection database = DatabaseConnection.GetInstance().database;
                database.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuery, database);
                retrievedEquipment = new DataTable();
                adapter.Fill(retrievedEquipment);
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            return retrievedEquipment;

        }
    }
}

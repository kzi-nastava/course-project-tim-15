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
            DataTable? retrivedStorage = null;
            string getAllQuery = "SELECT [RoomEquipment].RoomID, [RoomEquipment].EquipmentID, [Room].Number, [RoomType].Name as 'Room Type', [Equipment].Name as Equipment, " +
                                 "[EquipmentType].Name as 'Equipment Type', [RoomEquipment].Quantity " +
                                 "FROM [RoomEquipment], [Room], [Equipment], [EquipmentType], [RoomType] " +
                                 "WHERE [RoomEquipment].RoomID = [Room].ID AND [RoomEquipment].EquipmentID = [Equipment].ID " +
                                 "AND [Equipment].TypeID = [EquipmentType].ID AND [Room].Type = [RoomType].ID";

            string getStorageQuery = "SELECT 0 as RoomID, [Storage].EquipmentID, 0 as Number, 'Storage' as 'Room Type', [Equipment].Name as Equipment, " +
                                     "[EquipmentType].Name as 'Equipment Type', [Storage].Quantity " +
                                     "FROM [Storage], [EquipmentType], [Equipment] " +
                                     "WHERE [Storage].EquipmentID = [Equipment].ID AND [Equipment].TypeID = [EquipmentType].ID";
            try
            {
                SqlConnection database = DatabaseConnection.GetInstance().database;
                retrievedEquipment = new DataTable();
                retrivedStorage = new DataTable();

                database.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuery, database);
                adapter.Fill(retrievedEquipment);

                adapter = new SqlDataAdapter(getStorageQuery, database);
                adapter.Fill(retrivedStorage);

                retrievedEquipment.Merge(retrivedStorage);

                database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            return retrievedEquipment;
        }

        public static void Transfer(Models.EquipmentTransfer transfer)
        {
            string transferFromQuery = "UPDATE [RoomEquipment] " +
                "SET Quantity = @Quantity " +
                "WHERE RoomID = @RoomID AND EquipmentID = @EquipmentID";

            string checkQuery = "SELECT Quantity FROM [RoomEquipment] " +
                "WHERE RoomID = @RoomID AND EquipmentID = @EquipmentID";

            string updateQuery = "UPDATE [RoomEquipment] " +
                "SET Quantity = @Quantity " +
                "WHERE RoomID = @RoomID AND EquipmentID = @EquipmentID";

            string insertQuery = "INSERT INTO [RoomEquipment] " +
                "(RoomID, EquipmentID, Quantity) " +
                "VALUES (@RoomID, @EquipmentID, @Quantity)";

            try
            {
                SqlCommand fromTransfer = new SqlCommand(transferFromQuery, DatabaseConnection.GetInstance().database);
                fromTransfer.Parameters.AddWithValue("@Quantity", transfer.maxQuantity - transfer.quantity);
                fromTransfer.Parameters.AddWithValue("@RoomID", transfer.fromId);
                fromTransfer.Parameters.AddWithValue("@EquipmentID", transfer.equipment);

                SqlCommand toCheck = new SqlCommand(checkQuery, DatabaseConnection.GetInstance().database);
                toCheck.Parameters.AddWithValue("@Quantity", transfer.maxQuantity - transfer.quantity);
                toCheck.Parameters.AddWithValue("@RoomID", transfer.toId);
                toCheck.Parameters.AddWithValue("@EquipmentID", transfer.equipment);

                DatabaseConnection.GetInstance().database.Open();

                SqlDataReader readCheck = toCheck.ExecuteReader();
                if (readCheck.Read())
                {
                    SqlCommand update = new SqlCommand(updateQuery, DatabaseConnection.GetInstance().database);
                    update.Parameters.AddWithValue("@Quantity", transfer.equipment + (int)readCheck["Quantity"]);
                    update.Parameters.AddWithValue("@RoomID", transfer.toId);
                    update.Parameters.AddWithValue("@EquipmentID", transfer.equipment);
                    readCheck.Close();
                    update.ExecuteNonQuery();
                }
                else
                {
                    readCheck.Close();
                    SqlCommand insert = new SqlCommand(insertQuery, DatabaseConnection.GetInstance().database);
                    insert.Parameters.AddWithValue("@Quantity", transfer.quantity);
                    insert.Parameters.AddWithValue("@RoomID", transfer.toId);
                    insert.Parameters.AddWithValue("@EquipmentID", transfer.equipment);
                    insert.ExecuteNonQuery();
                }

                fromTransfer.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}

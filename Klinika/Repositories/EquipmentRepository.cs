using Klinika.Data;
using Klinika.Models;
using System.Collections.Generic;
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
            string getAllQuery = "SELECT [RoomEquipment].RoomID, [Room].Number, [RoomType].Name as 'Room Type',[RoomEquipment].EquipmentID, [Equipment].Name as Equipment, " +
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

        public static void TransferRequest(Models.EquipmentTransfer transfer)
        {
            string requestQuery = "INSERT INTO [EquipmentTransferRequest] " +
                "(FromID, ToID, EquipmentID, Quantity, Date, MaxQuantity, Done) " +
                "VALUES (@FromID, @ToID, @EquipmentID, @Quantity, @Date, @MaxQuantity, 0)";
            try
            {
                SqlCommand create = new SqlCommand(requestQuery, DatabaseConnection.GetInstance().database);
                create.Parameters.AddWithValue("@FromID", transfer.fromId);
                create.Parameters.AddWithValue("@ToID", transfer.toId);
                create.Parameters.AddWithValue("@EquipmentID", transfer.equipment);
                create.Parameters.AddWithValue("@Quantity", transfer.quantity);
                create.Parameters.AddWithValue("@Date", transfer.transfer.ToString("yyyy-MM-dd"));
                create.Parameters.AddWithValue("@MaxQuantity", transfer.maxQuantity);
                DatabaseConnection.GetInstance().database.Open();
                create.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
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
                //If storage is one of the transfer rooms
                if (transfer.toId == 0)
                {
                    SqlCommand fromTransfer = new SqlCommand(transferFromQuery, DatabaseConnection.GetInstance().database);
                    fromTransfer.Parameters.AddWithValue("@Quantity", transfer.maxQuantity - transfer.quantity);
                    fromTransfer.Parameters.AddWithValue("@RoomID", transfer.fromId);
                    fromTransfer.Parameters.AddWithValue("@EquipmentID", transfer.equipment);

                    DatabaseConnection.GetInstance().database.Open();

                    checkQuery = "SELECT Quantity FROM [Storage] " +
                        "WHERE EquipmentID = @EquipmentID";

                    SqlCommand toCheck = new SqlCommand(checkQuery, DatabaseConnection.GetInstance().database);
                    toCheck.Parameters.AddWithValue("@EquipmentID", transfer.equipment);

                    SqlDataReader readCheck = toCheck.ExecuteReader();
                    if (readCheck.Read())
                    {
                        updateQuery = "UPDATE [Storage] " +
                        "SET Quantity = @Quantity " +
                        "WHERE EquipmentID = @EquipmentID";
                        SqlCommand update = new SqlCommand(updateQuery, DatabaseConnection.GetInstance().database);
                        update.Parameters.AddWithValue("@Quantity", transfer.quantity + (int)readCheck["Quantity"]);
                        update.Parameters.AddWithValue("@EquipmentID", transfer.equipment);
                        readCheck.Close();
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        insertQuery = "INSERT INTO [Storage] " +
                        "(EquipmentID, Quantity) " +
                        "VALUES (@EquipmentID, @Quantity)";
                        readCheck.Close();
                        SqlCommand insert = new SqlCommand(insertQuery, DatabaseConnection.GetInstance().database);
                        insert.Parameters.AddWithValue("@Quantity", transfer.quantity);
                        insert.Parameters.AddWithValue("@EquipmentID", transfer.equipment);
                        insert.ExecuteNonQuery();
                    }

                    fromTransfer.ExecuteNonQuery();
                    DatabaseConnection.GetInstance().database.Close();
                }

                else if (transfer.fromId == 0)
                {
                    transferFromQuery = "UPDATE [Storage] " +
                        "SET Quantity = @Quantity " +
                        "WHERE EquipmentID = @EquipmentID";

                    SqlCommand fromTransfer = new SqlCommand(transferFromQuery, DatabaseConnection.GetInstance().database);
                    fromTransfer.Parameters.AddWithValue("@Quantity", transfer.maxQuantity - transfer.quantity);
                    fromTransfer.Parameters.AddWithValue("@RoomID", transfer.fromId);
                    fromTransfer.Parameters.AddWithValue("@EquipmentID", transfer.equipment);

                    SqlCommand toCheck = new SqlCommand(checkQuery, DatabaseConnection.GetInstance().database);
                    toCheck.Parameters.AddWithValue("@RoomID", transfer.toId);
                    toCheck.Parameters.AddWithValue("@EquipmentID", transfer.equipment);

                    DatabaseConnection.GetInstance().database.Open();

                    SqlDataReader readCheck = toCheck.ExecuteReader();
                    if (readCheck.Read())
                    {
                        SqlCommand update = new SqlCommand(updateQuery, DatabaseConnection.GetInstance().database);
                        update.Parameters.AddWithValue("@Quantity", transfer.quantity + (int)readCheck["Quantity"]);
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

                else
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
                        update.Parameters.AddWithValue("@Quantity", transfer.quantity + (int)readCheck["Quantity"]);
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
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void CheckEquipmentTransfers()
        {
            string getRequestsQuery = "SELECT [EquipmentTransferRequest].ID, [EquipmentTransferRequest].FromID, [EquipmentTransferRequest].ToID, [EquipmentTransferRequest].EquipmentID, [EquipmentTransferRequest].Quantity, [EquipmentTransferRequest].Date, [EquipmentTransferRequest].MaxQuantity, [EquipmentTransferRequest].Done " +
                "FROM [EquipmentTransferRequest]";

            string doneQuery = "UPDATE [EquipmentTransferRequest] " +
                                 "SET Done = 1 " +
                                 "WHERE ID = @ID";

            DataTable requests = new DataTable();
            try
            {
                SqlConnection database = DatabaseConnection.GetInstance().database;
                database.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(getRequestsQuery, database);
                adapter.Fill(requests);
                database.Close();

                Models.EquipmentTransfer transfer = new Models.EquipmentTransfer();

                if (requests.Rows.Count > 0)
                {
                    foreach (DataRow row in requests.Rows)
                    {
                        transfer.transfer = DateTime.Parse(row["Date"].ToString());

                        if (transfer.transfer <= DateTime.Now && (bool)row["Done"] == false)
                        {
                            transfer.quantity = (int)row["Quantity"];
                            transfer.maxQuantity = (int)row["MaxQuantity"];
                            transfer.fromId = (int)row["FromID"];
                            transfer.toId = (int)row["ToID"];
                            transfer.equipment = (int)row["EquipmentID"];

                            database.Open();
                            SqlCommand modify = new SqlCommand(doneQuery, DatabaseConnection.GetInstance().database);
                            modify.Parameters.AddWithValue("@ID", (int)row["ID"]);
                            modify.ExecuteNonQuery();
                            database.Close();
                            Transfer(transfer);
                        }
                    }
                }
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static DataTable GetDynamicEquipmentInStorage()
        {
            string getQuery = "SELECT [Equipment].ID, [Equipment].Name, ISNULL([Storage].Quantity,0) 'Quantity' FROM [Equipment] " +
                              "LEFT OUTER JOIN [EquipmentType] ON [Equipment].TypeID = [EquipmentType].ID " +
                              "LEFT OUTER JOIN [Storage] ON [Equipment].ID = [Storage].EquipmentID " +
                              "WHERE [EquipmentType].Name = 'dynamic'";
            return DatabaseConnection.GetInstance().CreateTableOfData(getQuery);
        }

        public static int GetQuantity(int roomId, int equipmentId)
        {
            string getQuery = "SELECT Quantity FROM [RoomEquipment] " +
                              "WHERE RoomID = @roomId AND EquipmentID = @equipId";
            object quantity = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(getQuery, ("@roomId", roomId), ("@equipId", equipmentId));
            if (quantity != null) return (int)quantity;
            return 0;
        }

        public static int GetQuantityFromStorage(int equipmentId)
        {
            string getQuery = "SELECT Quantity FROM [Storage] " +
                              "WHERE EquipmentID = @equipId";
            object quantity = DatabaseConnection.GetInstance().ExecuteNonQueryScalarCommand(getQuery, ("@equipId", equipmentId));
            if (quantity != null) return (int)quantity;
            return 0;
        }

        public static List<Equipment> GetDynamicEquipmentInRooms()
        {
            string getQuery = "SELECT [Equipment].ID, [Equipment].Name, [RoomEquipment].RoomID, [RoomEquipment].Quantity FROM [Equipment] " +
                              "LEFT OUTER JOIN [EquipmentType] ON [Equipment].TypeID = [EquipmentType].ID " +
                              "LEFT OUTER JOIN [RoomEquipment] ON [Equipment].ID = [RoomEquipment].EquipmentID " +
                              "WHERE [EquipmentType].Name = 'dynamic'";

            DataTable allDynamicEquipmentInRoom = DatabaseConnection.GetInstance().CreateTableOfData(getQuery);

            List<Equipment> equipment = new List<Equipment>();
            foreach(DataRow row in allDynamicEquipmentInRoom.Rows)
            {
                equipment.Add(new Equipment(
                    id: Convert.ToInt32(row["ID"]),
                    name: DatabaseConnection.CheckNull<string>(row["Name"]),
                    roomID: DatabaseConnection.CheckNull<int>(row["RoomID"]),
                    quantity: DatabaseConnection.CheckNull<int>(row["Quantity"])));
            }
            return equipment;
        }
        public static void ModifyRoomsDynamicEquipmentQuantity(int roomID, int equipmentID, int quantity)
        {
            string modifyQuery = "UPDATE [RoomEquipment] " +
                "SET Quantity = @Quantity " +
                "WHERE RoomID = @RoomID AND EquipmentID = @EquipmentID";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                modifyQuery,
                ("@RoomID", roomID),
                ("@EquipmentID", equipmentID),
                ("@Quantity", quantity));
        }

    }
}
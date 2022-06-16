using Klinika.Core;
using Klinika.Core.Database;
using Klinika.Rooms.Interfaces;
using Klinika.Rooms.Models;
using System.Data;
using System.Data.SqlClient;

namespace Klinika.Rooms.Repositories
{
    internal class EquipmentRepository : Repository, IRoomEquipmentRepo, ITransferRepo
    {
        public List<Equipment> GetAllInRooms()
        {
            List<Equipment> equipmentInRooms = new List<Equipment>();

            string getAllQuery = "SELECT [RoomEquipment].RoomID,[Room].Number, [RoomEquipment].EquipmentID, [Equipment].Name as Equipment, " +
                     "[RoomEquipment].Quantity " +
                     "FROM [RoomEquipment], [Equipment], [Room] " +
                     "WHERE [RoomEquipment].EquipmentID = [Equipment].ID AND [RoomEquipment].RoomID = [Room].ID";
            DataTable retrievedEquipment = database.CreateTableOfData(getAllQuery);
            foreach (DataRow equipment in retrievedEquipment.Rows)
            {
                equipmentInRooms.Add(new Equipment((int)equipment["EquipmentID"],
                                                   equipment["Equipment"].ToString(),
                                                   (int)equipment["RoomID"],
                                                   (int)equipment["Number"],
                                                   (int)equipment["Quantity"]
                                    ));
            }
            return equipmentInRooms;
        }

        public DataTable GetAll()
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
            retrievedEquipment = database.CreateTableOfData(getAllQuery);
            retrievedEquipment.Merge(database.CreateTableOfData(getStorageQuery));
            return retrievedEquipment;
        }

        public void TransferRequest(EquipmentTransfer transfer)
        {
            string requestQuery = "INSERT INTO [EquipmentTransferRequest] " +
                "(FromID, ToID, EquipmentID, Quantity, Date, MaxQuantity, Done) " +
                "VALUES (@FromID, @ToID, @EquipmentID, @Quantity, @Date, @MaxQuantity, 0)";
            database.ExecuteNonQueryCommand(requestQuery, ("@FromID", transfer.fromId), ("@ToID", transfer.toId), ("@EquipmentID", transfer.equipment), ("@Quantity", transfer.quantity), ("@Date", transfer.transfer.ToString("yyyy-MM-dd")), ("@MaxQuantity", transfer.maxQuantity));
        }

        public List<Equipment> GetDynamicEquipmentInStorage()
        {
            List<Equipment> dynamicEquipmentInStorage = new List<Equipment>();
            string getQuery = "SELECT [Equipment].ID, [Equipment].Name, ISNULL([Storage].Quantity,0) 'Quantity' FROM [Equipment] " +
                              "LEFT OUTER JOIN [EquipmentType] ON [Equipment].TypeID = [EquipmentType].ID " +
                              "LEFT OUTER JOIN [Storage] ON [Equipment].ID = [Storage].EquipmentID " +
                              "WHERE [EquipmentType].Name = 'dynamic'";
            DataTable retrieved = database.CreateTableOfData(getQuery);
            foreach (DataRow equipment in retrieved.Rows)
            {
                dynamicEquipmentInStorage.Add(new Equipment((int)equipment["ID"],
                                                            equipment["Name"].ToString(),
                                                            0,
                                                            (int)equipment["Quantity"],
                                                            Equipment.EquipmentType.DYNAMIC
                                                            ));
            }
            return dynamicEquipmentInStorage;
        }

        public int GetQuantity(int roomId, int equipmentId)
        {
            string getQuery = "SELECT Quantity FROM [RoomEquipment] " +
                              "WHERE RoomID = @roomId AND EquipmentID = @equipId";
            object quantity = database.ExecuteNonQueryScalarCommand(getQuery, ("@roomId", roomId), ("@equipId", equipmentId));
            if (quantity != null) return (int)quantity;
            return 0;
        }

        public int GetQuantityFromStorage(int equipmentId)
        {
            string getQuery = "SELECT Quantity FROM [Storage] " +
                              "WHERE EquipmentID = @equipId";
            object quantity = database.ExecuteNonQueryScalarCommand(getQuery, ("@equipId", equipmentId));
            if (quantity != null) return (int)quantity;
            return 0;
        }

        public List<Equipment> GetDynamicEquipmentInRooms()
        {
            string getQuery = "SELECT [Equipment].ID, [Equipment].Name, [RoomEquipment].RoomID, [RoomEquipment].Quantity FROM [Equipment] " +
                              "LEFT OUTER JOIN [EquipmentType] ON [Equipment].TypeID = [EquipmentType].ID " +
                              "LEFT OUTER JOIN [RoomEquipment] ON [Equipment].ID = [RoomEquipment].EquipmentID " +
                              "WHERE [EquipmentType].Name = 'dynamic'";

            DataTable allDynamicEquipmentInRoom = database.CreateTableOfData(getQuery);

            List<Equipment> equipment = new List<Equipment>();
            foreach (DataRow row in allDynamicEquipmentInRoom.Rows)
            {
                equipment.Add(new Equipment(
                    id: Convert.ToInt32(row["ID"]),
                    name: DatabaseConnection.CheckNull<string>(row["Name"]),
                    roomID: DatabaseConnection.CheckNull<int>(row["RoomID"]),
                    quantity: DatabaseConnection.CheckNull<int>(row["Quantity"])));
            }
            return equipment;
        }

        public void ModifyRoomsDynamicEquipmentQuantity(int roomID, int equipmentID, int quantity)
        {
            string modifyQuery = "UPDATE [RoomEquipment] " +
                "SET Quantity = @Quantity " +
                "WHERE RoomID = @RoomID AND EquipmentID = @EquipmentID";
            database.ExecuteNonQueryCommand(
                modifyQuery,
                ("@RoomID", roomID),
                ("@EquipmentID", equipmentID),
                ("@Quantity", quantity));
        }

    }
}
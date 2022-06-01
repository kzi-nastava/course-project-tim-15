using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Repositories;
using System.Data;
using Klinika.Models;

namespace Klinika.Services
{
    internal class EquipmentService
    {
        public static DataTable GetMissingDynamicEquipment()
        {
            DataTable allDynamicEquipment = EquipmentRepository.GetDynamicEquipmentInStorage();
            for (int i = allDynamicEquipment.Rows.Count - 1; i >= 0; i--)
            {
                if ((int)allDynamicEquipment.Rows[i]["Quantity"] > 0) allDynamicEquipment.Rows.RemoveAt(i);
            }
            allDynamicEquipment.Columns.Remove("Quantity");
            return allDynamicEquipment;
        }
        public static List<Equipment> GetDynamicEquipment(int roomID)
        {
            var equipment = EquipmentRepository.GetDynamicEquipmentInRooms();
            return equipment.Where(x => x.roomID == roomID).ToList();
        }
        public static void UpdateRoomsDynamicEquipment(int roomID, List<Equipment> equipments)
        {
            foreach(var equipment in equipments)
            {
                EquipmentRepository.ModifyRoomsDynamicEquipmentQuantity(roomID, equipment.id, equipment.GetNewQuantity());
            }
        }
        public static void MakeEquipmentTransferRequest(int equipmentId,int quantity)
        {
            EquipmentTransfer newTransfer = new EquipmentTransfer(-1,
                                                                  quantity,
                                                                  0,
                                                                  quantity,
                                                                  equipmentId,
                                                                  DateTime.Now.AddDays(1));
            EquipmentRepository.TransferRequest(newTransfer);
        }
       
        private static DataTable PairRoomWithAllDynamicEquipment()
        {
            DataTable rooms = RoomRepository.GetAllRooms();
            DataTable dynamicEquipment = EquipmentRepository.GetDynamicEquipmentInStorage();
            DataTable pairs = new DataTable();
            pairs.Columns.Add("RoomID", typeof(int));
            pairs.Columns.Add("Number", typeof(int));
            pairs.Columns.Add("EquipmentID", typeof(int));
            pairs.Columns.Add("EquipmentName", typeof(string));
            pairs.Columns.Add("Quantity", typeof(int));
            foreach (DataRow room in rooms.Rows)
            {
                foreach(DataRow equipment in dynamicEquipment.Rows)
                {
                    pairs.Rows.Add((int)room["ID"], (int)room["Number"], (int)equipment["ID"], equipment["Name"].ToString(), 0);
                }
            }
            return pairs;
        }

        private static DataTable GetQuantities(DataTable roomEquipmentPairs)
        {
            DataTable registeredEquipmentInRooms = EquipmentRepository.GetAll();
            foreach(DataRow pair in roomEquipmentPairs.Rows)
            {
                foreach(DataRow registeredEquipment in registeredEquipmentInRooms.Rows)
                {
                    if (!pair["RoomID"].ToString().Equals(registeredEquipment["RoomID"].ToString()) ||
                        !pair["EquipmentID"].ToString().Equals(registeredEquipment["EquipmentID"].ToString())) continue;
                    
                    pair["Quantity"] = (int)registeredEquipment["Quantity"];
                    break;
                }
            }
            return roomEquipmentPairs;
        }

        private static DataTable GetLowStockDynamicEquipmentInRooms(DataTable dynamicEquipmentInRooms)
        {
            for (int i = dynamicEquipmentInRooms.Rows.Count - 1; i >= 0; i--)
            {
                if ((int)dynamicEquipmentInRooms.Rows[i]["Quantity"] >= 5) dynamicEquipmentInRooms.Rows.RemoveAt(i);
            }

            return dynamicEquipmentInRooms;
        }

        public static DataTable GetDynamicEquipmentInRooms()
        {
            DataTable roomDynamicEquipmentPairs = PairRoomWithAllDynamicEquipment();
            roomDynamicEquipmentPairs = GetQuantities(roomDynamicEquipmentPairs);
            roomDynamicEquipmentPairs = GetLowStockDynamicEquipmentInRooms(roomDynamicEquipmentPairs);
            roomDynamicEquipmentPairs.DefaultView.Sort = "Number asc";
            return roomDynamicEquipmentPairs;
        }

        public static int GetQuantity(int roomId, int equipmentId)
        {
            if(roomId != 0) return EquipmentRepository.GetQuantity(roomId, equipmentId);
            return EquipmentRepository.GetQuantityFromStorage(equipmentId);
        }

    }
}

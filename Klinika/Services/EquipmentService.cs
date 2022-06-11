using Klinika.Models;
using Klinika.Repositories;
using System.Data;
using Klinika.Interfaces;

namespace Klinika.Services
{
    internal class EquipmentService
    {
        private readonly IRoomEquipmentRepo roomEquipmentRepo;
        public EquipmentService(IRoomEquipmentRepo roomEquipmentRepo) => this.roomEquipmentRepo = roomEquipmentRepo;
        public static List<Equipment> GetMissingDynamicEquipment()
        {
            List<Equipment> allDynamicEquipment = EquipmentRepository.GetDynamicEquipmentInStorage();
            for (int i = allDynamicEquipment.Count - 1; i >= 0; i--)
            {
                if (allDynamicEquipment[i].quantity > 0) allDynamicEquipment.RemoveAt(i);
            }
            return allDynamicEquipment;
        }
        public List<Equipment> GetDynamicEquipment(int roomID)
        {
            var equipment = roomEquipmentRepo.GetDynamicEquipmentInRooms();
            return equipment.Where(x => x.roomID == roomID).ToList();
        }
        public void UpdateRoomsDynamicEquipment(int roomID, List<Equipment> equipments)
        {
            foreach(var equipment in equipments) roomEquipmentRepo.ModifyRoomsDynamicEquipmentQuantity(roomID, equipment.id, equipment.GetNewQuantity());
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
       
        private static List<Equipment> PairRoomWithAllDynamicEquipment()
        {
            //TODO
            List<Room> rooms = new List<Room>(); //RoomRepository.Get(); 
            List<Equipment> dynamicEquipment = EquipmentRepository.GetDynamicEquipmentInStorage();
            List<Equipment> pairs = new List<Equipment>();

            foreach (Room room in rooms)
            {
                foreach(Equipment equipment in dynamicEquipment)
                {
                    pairs.Add(new Equipment(
                                            equipment.id,
                                            equipment.name,
                                            room.id,
                                            room.number,
                                            0
                                            ));
                }
            }
            return pairs;
        }

        private static List<Equipment> GetQuantities(List<Equipment> roomEquipmentPairs)
        {
            List<Equipment> registeredEquipmentInRooms = EquipmentRepository.GetAllInRooms();
            foreach(Equipment pair in roomEquipmentPairs)
            {
                foreach(Equipment registeredEquipment in registeredEquipmentInRooms)
                {
                    if (pair.roomID != registeredEquipment.roomID ||
                        pair.id != registeredEquipment.id) continue;
                    
                    pair.quantity = registeredEquipment.quantity;
                    break;
                }
            }
            return roomEquipmentPairs;
        }

        private static List<Equipment> GetLowStockDynamicEquipmentInRooms(List<Equipment> dynamicEquipmentInRooms)
        {
            for (int i = dynamicEquipmentInRooms.Count - 1; i >= 0; i--)
            {
                if (dynamicEquipmentInRooms[i].quantity >= 5) dynamicEquipmentInRooms.RemoveAt(i);
            }

            return dynamicEquipmentInRooms;
        }

        public static List<Equipment> GetDynamicEquipmentInRooms()
        {
            List<Equipment> roomDynamicEquipmentPairs = PairRoomWithAllDynamicEquipment();
            roomDynamicEquipmentPairs = GetQuantities(roomDynamicEquipmentPairs);
            roomDynamicEquipmentPairs = GetLowStockDynamicEquipmentInRooms(roomDynamicEquipmentPairs);
            return roomDynamicEquipmentPairs.OrderBy(o => o.roomID).ToList();
        }

        public static int GetQuantity(int roomId, int equipmentId)
        {
            if(roomId != 0) return EquipmentRepository.GetQuantity(roomId, equipmentId);
            return EquipmentRepository.GetQuantityFromStorage(equipmentId);
        }

    }
}

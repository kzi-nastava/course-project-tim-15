using Klinika.Interfaces;
using Klinika.Models;
using Klinika.Repositories;
using System.Data;

namespace Klinika.Services
{
    internal class EquipmentService
    {
        private readonly IRoomEquipmentRepo roomEquipmentRepo;
        private readonly ITransferRepo transferRepo;
        public EquipmentService(IRoomEquipmentRepo roomEquipmentRepo, ITransferRepo transferRepo)
        {
            this.roomEquipmentRepo = roomEquipmentRepo;
            this.transferRepo = transferRepo;
        }

        public List<Equipment> GetMissingDynamicEquipment()
        {
            List<Equipment> allDynamicEquipment = roomEquipmentRepo.GetDynamicEquipmentInStorage();
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
        public void MakeEquipmentTransferRequest(int equipmentId,int quantity)
        {
            EquipmentTransfer newTransfer = new EquipmentTransfer(-1,
                                                                  quantity,
                                                                  0,
                                                                  quantity,
                                                                  equipmentId,
                                                                  DateTime.Now.AddDays(1));
            transferRepo.TransferRequest(newTransfer);
        }
       
        private List<Equipment> PairRoomWithAllDynamicEquipment()
        {
            List<Room> rooms = new List<Room>(); 
            List<Equipment> dynamicEquipment = roomEquipmentRepo.GetDynamicEquipmentInStorage();
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

        private List<Equipment> GetQuantities(List<Equipment> roomEquipmentPairs)
        {
            List<Equipment> registeredEquipmentInRooms = roomEquipmentRepo.GetAllInRooms();
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

        private List<Equipment> GetLowStockDynamicEquipmentInRooms(List<Equipment> dynamicEquipmentInRooms)
        {
            for (int i = dynamicEquipmentInRooms.Count - 1; i >= 0; i--)
            {
                if (dynamicEquipmentInRooms[i].quantity >= 5) dynamicEquipmentInRooms.RemoveAt(i);
            }

            return dynamicEquipmentInRooms;
        }

        public List<Equipment> GetDynamicEquipmentInRooms()
        {
            List<Equipment> roomDynamicEquipmentPairs = PairRoomWithAllDynamicEquipment();
            roomDynamicEquipmentPairs = GetQuantities(roomDynamicEquipmentPairs);
            roomDynamicEquipmentPairs = GetLowStockDynamicEquipmentInRooms(roomDynamicEquipmentPairs);
            return roomDynamicEquipmentPairs.OrderBy(o => o.roomID).ToList();
        }

        public int GetQuantity(int roomId, int equipmentId)
        {
            if(roomId != 0) return roomEquipmentRepo.GetQuantity(roomId, equipmentId);
            return roomEquipmentRepo.GetQuantityFromStorage(equipmentId);
        }

    }
}

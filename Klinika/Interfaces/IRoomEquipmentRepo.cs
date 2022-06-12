using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface IRoomEquipmentRepo
    {
        List<Equipment> GetDynamicEquipmentInRooms();
        void ModifyRoomsDynamicEquipmentQuantity(int roomID, int equipmentID, int quantity);
        public List<Equipment> GetDynamicEquipmentInStorage();
        public int GetQuantity(int roomId, int equipmentId);
        public int GetQuantityFromStorage(int equipmentId);
        public List<Equipment> GetAllInRooms();
    }
}

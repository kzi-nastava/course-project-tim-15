using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface IRoomEquipmentRepo
    {
        List<Equipment> GetDynamicEquipmentInRooms();
        void ModifyRoomsDynamicEquipmentQuantity(int roomID, int equipmentID, int quantity);
    }
}

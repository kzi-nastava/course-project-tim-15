using Klinika.Rooms.Models;

namespace Klinika.Rooms.Services
{
    public class TransferService
    {
        public static bool TransferReady(EquipmentTransfer transfer)
        {
            if (transfer.fromId == -1)
            {
                return false;
            }
            if (transfer.toId == -1)
            {
                return false;
            }
            if (transfer.maxQuantity == 0)
            {
                return false;
            }
            if (transfer.toId == transfer.fromId)
            {
                return false;
            }
            return true;
        }
    }
}

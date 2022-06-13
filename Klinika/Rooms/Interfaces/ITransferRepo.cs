using Klinika.Rooms.Models;

namespace Klinika.Rooms.Interfaces
{
    public interface ITransferRepo
    {
        public void TransferRequest(EquipmentTransfer transfer);
    }
}

using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface ITransferRepo
    {
        public void TransferRequest(Models.EquipmentTransfer transfer);
    }
}

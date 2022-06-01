﻿namespace Klinika.Services
{
    internal class ManagerServices
    {
        public static bool TransferReady(Models.EquipmentTransfer transfer)
        {
            if (transfer.fromId == -1)
            {
                return false;
            }
            if (transfer.toId == -1)
            {
                return false;
            }
            if(transfer.maxQuantity == 0)
            {
                return false;
            }
            if(transfer.toId == transfer.fromId)
            {
                return false;
            }
            return true;
        }
    }
}

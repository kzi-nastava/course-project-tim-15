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
            return EquipmentRepository.GetMissingDynamicEquipment();
        }
        public static DataTable GetDynamicEquipment(int roomID)
        {
            return EquipmentRepository.GetDynamicEquipment(roomID);
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
    }
}

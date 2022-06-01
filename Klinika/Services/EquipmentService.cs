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
            DataTable allDynamicEquipment = EquipmentRepository.GetDynamicEquipment();
            for (int i = allDynamicEquipment.Rows.Count - 1; i >= 0; i--)
            {
                if ((int)allDynamicEquipment.Rows[i]["Quantity"] > 0) allDynamicEquipment.Rows.RemoveAt(i);
            }
            allDynamicEquipment.Columns.Remove("Quantity");
            return allDynamicEquipment;
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

        public static void GetDynamicEquipmentPerRoom(int roomId)
        {
           // DataTable registeredDynamicEquipmentInRoom = EquipmentRepository
        }
    }
}

﻿using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Interfaces
{
    public interface IRoomEquipmentRepo
    {
        List<Equipment> GetDynamicEquipmentInRooms();
        void ModifyRoomsDynamicEquipmentQuantity(int roomID, int equipmentID, int quantity);
    }
}
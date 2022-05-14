using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    internal class RoomServices
    {
        public static bool DateValid(Models.Renovation renovation)
        {
            return true;
        }
        public static bool IsRoomRenovating(int id, DateTime from, DateTime to)
        {
            bool renovating = false;
            if(Repositories.RoomRepository.IsRoomRenovating(id, from, to))
            {
                renovating = true;
            }
            return renovating;
        }
    }
}

using Klinika.Models;
using Klinika.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static List<Models.EnhancedComboBoxItem> GetRooms()
        {
            List<Models.EnhancedComboBoxItem> rooms = new List<Models.EnhancedComboBoxItem>();
            DataTable retrievedRooms = Repositories.RoomRepository.GetAllRoomsWithTypeNames();

            foreach (DataRow row in retrievedRooms.Rows)
            {
                rooms.Add(new Models.EnhancedComboBoxItem(row["Number"].ToString(), row["ID"].ToString()));
            }
            rooms = rooms.OrderBy(x => x.text).ToList();
            return rooms;
        }
        public static Room[] GetOperationRooms()
        {
            return RoomRepository.Get().Where(x => x.Type == 1).ToArray();
        }
        public static List<Room> GetExaminationRooms()
        {
            return RoomRepository.Get().Where(x => x.Type == 2).ToList();
        }
        public static Room? GetSingle(int id)
        {
            return RoomRepository.Get().Where(x => x.ID == id).FirstOrDefault();
        }
    }
}

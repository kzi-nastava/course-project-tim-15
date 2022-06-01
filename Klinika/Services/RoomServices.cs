using Klinika.Models;
using Klinika.Repositories;
using System.Data;

namespace Klinika.Services
{
    internal class RoomServices
    {
        public static bool DateValid(Models.Renovation renovation)
        {
            return true;
        }
        public static bool IsOccupied(DateTime start, int roomID, int duration = 15, int forAppointmentID = -1)
        {
            return IsOccupied(roomID, new TimeSlot(start, duration), forAppointmentID);
        }
        private static bool IsOccupied(int roomID, TimeSlot slot, int forAppointmentID = -1)
        {
            List<Appointment> forSelectedTimeSpan = AppointmentRepository.GetInstance().appointments.Where(
                x => x.roomID == roomID && slot.DoesOverlap(new TimeSlot(x.dateTime, x.duration)) && !x.isDeleted && x.id != forAppointmentID).ToList();

            if (forSelectedTimeSpan.Count == 0) return false;
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
            rooms.Add(new Models.EnhancedComboBoxItem("Storage", "0"));
            rooms = rooms.OrderBy(x => x.text).ToList();
            return rooms;
        }

        public static Room[] GetOperationRooms()
        {
            return RoomRepository.Get().Where(x => x.type == 1).ToArray();
        }
        public static List<Room> GetExaminationRooms()
        {
            return RoomRepository.Get().Where(x => x.type == 2).ToList();
        }
        public static Room? GetSingle(int id)
        {
            return RoomRepository.Get().Where(x => x.id == id).FirstOrDefault();
        }
    }
}

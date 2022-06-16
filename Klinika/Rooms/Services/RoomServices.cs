using Klinika.Appointments.Models;
using Klinika.Core;
using Klinika.Rooms.Interfaces;
using Klinika.Rooms.Models;
using Klinika.Rooms.Repositories;
using Klinika.Schedule;
using Klinika.Schedule.Models;
using System.Data;

namespace Klinika.Rooms.Services
{
    internal class RoomServices
    {
        private readonly IRoomRepo roomRepo;
        private readonly IScheduledAppointmentsRepo appointmentsRepo;
        public RoomServices(IRoomRepo roomRepo, IScheduledAppointmentsRepo appointmentsRepo)
        {
            this.roomRepo = roomRepo;
            this.appointmentsRepo = appointmentsRepo;
        }
        public static bool DateValid(Renovation renovation)
        {
            return true;
        }
        public bool IsOccupied(int roomID, TimeSlot slot, int forAppointmentID = -1)
        {
            List<Appointment> forSelectedTimeSpan = appointmentsRepo.GetAll().Where(
                x => x.roomID == roomID && slot.DoesOverlap(new TimeSlot(x.dateTime, x.duration)) && !x.isDeleted && x.id != forAppointmentID).ToList();
            if (forSelectedTimeSpan.Count == 0) return false;
            return true;
        }
        public Room? GetDoctorOffice(int officeID) => GetExaminationRooms().Where(x => x.id == officeID).FirstOrDefault();
        public Room[] GetOperationRooms() => roomRepo.Get().Where(x => x.type == 1).ToArray();
        public List<Room> GetExaminationRooms() => roomRepo.Get().Where(x => x.type == 2).ToList();
        public Room? GetSingle(int id) => roomRepo.Get().Where(x => x.id == id).FirstOrDefault();

        public static bool IsRoomRenovating(int id, DateTime from, DateTime to)
        {
            bool renovating = false;
            return renovating;
        }

        public static List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();

            return rooms;
        }
        public static List<EnhancedComboBoxItem> GetRooms()
        {
            List<EnhancedComboBoxItem> rooms = new List<EnhancedComboBoxItem>();
            DataTable retrievedRooms = RoomRepository.GetAllRoomsWithTypeNames();

            foreach (DataRow row in retrievedRooms.Rows)
            {
                rooms.Add(new EnhancedComboBoxItem(row["Number"].ToString(), row["ID"].ToString()));
            }
            rooms.Add(new EnhancedComboBoxItem("Storage", "0"));
            rooms = rooms.OrderBy(x => x.text).ToList();
            return rooms;
        }
    }
}

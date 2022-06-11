﻿using Klinika.Models;
using Klinika.Repositories;
using System.Data;
using Klinika.Interfaces;

namespace Klinika.Services
{
    internal class RoomServices
    {
        private readonly IRoomRepo roomRepo;
        public RoomServices(IRoomRepo roomRepo) => this.roomRepo = roomRepo;
        public static bool DateValid(Models.Renovation renovation)
        {
            return true;
        }
        public bool IsOccupied(int roomID, TimeSlot slot, int forAppointmentID = -1)
        {
            List<Appointment> forSelectedTimeSpan = AppointmentRepository.GetInstance().appointments.Where(
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
    }
}

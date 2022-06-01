using Klinika.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Appointment
    {
        public enum Types { EXAMINATION = 'E', OPERATION = 'O' }
        public int id { get; set; }
        public int doctorID { get; set; }
        public int patientID { get; set; }
        public DateTime dateTime { get; set; }
        public int roomID { get; set; }
        public bool completed { get; set; }
        public char type { get; set; }
        public int duration { get; set; }
        public bool urgent { get; set; }
        public string? description { get; set; }
        public bool isDeleted { get; set; }

        public Appointment()
        {
            doctorID = -1;
            dateTime = DateTime.Now;
            isDeleted = false;
            completed = false;
            roomID = 1;
        }
        public Appointment(DateTime dateTime)
        {
            this.dateTime = dateTime;
            isDeleted = false;
            completed = false;
            roomID = 1;
        }
        public Appointment(int doctorID, int patientID, DateTime dateTime)
        {
            id = -1;
            this.doctorID = doctorID;
            this.patientID = patientID;
            this.dateTime = dateTime;
            roomID = 1;
            completed = false;
            type = 'E';
            duration = 15;
            urgent = false;
            description = "";
            isDeleted = false;
        }
        public Appointment (int id, int doctorID, int patientID, DateTime dateTime, int roomID,
                            bool completed, char type, int duration, bool urgent, string? description,
                            bool isDeleted)
        {
            this.id = id;
            this.doctorID = doctorID;
            this.patientID = patientID;
            this.dateTime = dateTime;
            this.roomID = roomID;
            this.completed = completed;
            this.type = type;
            this.duration = duration;
            this.urgent = urgent;
            this.description = description;
            this.isDeleted = isDeleted;
        }
        public bool IsBetween(TimeSlot timeSlot, int offsetMin = 0)
        {
            DateTime start = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, timeSlot.from.Hour, timeSlot.from.Minute, timeSlot.from.Second);
            DateTime end = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, timeSlot.to.Hour, timeSlot.to.Minute, timeSlot.to.Second);
            if (dateTime.AddMinutes(offsetMin) >= start && dateTime.AddMinutes(offsetMin) <= end)
            {
                return true;
            }
            return false;
        }
        public string GetType()
        {
            return AppointmentService.GetTypeFullName(type);
        }

        public bool IsExamination()
        {
            return type == (char)Types.EXAMINATION;
        }

    }
}

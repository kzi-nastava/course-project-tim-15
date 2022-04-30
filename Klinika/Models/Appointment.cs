using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime DateTime { get; set; }
        public int RoomID { get; set; }
        public bool Completed { get; set; }
        public char Type { get; set; }
        public int Duration { get; set; }
        public bool Urgent { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }

        public Appointment()
        {
            DateTime = DateTime.Now;
        }

        public Appointment (int id, int doctorID, int patientId, DateTime dateTime, int roomID,
                            bool completed, char type, int duration, bool urgent, string? description,
                            bool isDeleted)
        {
            ID = id;
            DoctorID = doctorID;
            PatientID = patientId;
            DateTime = dateTime;
            RoomID = roomID;
            Completed = completed;
            Type = type;
            Duration = duration;
            Urgent = urgent;
            Description = description;
            IsDeleted = isDeleted;
        }
    }
}

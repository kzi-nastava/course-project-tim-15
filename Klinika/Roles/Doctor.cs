using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using Klinika.Repositories;
using Klinika.Data;
using System.Data;
using Klinika.Services;

namespace Klinika.Roles
{
    internal class Doctor : User
    {
        public Specialization specialization { get; set; }
        public Doctor(int id, string name, string surname,Specialization specialization) : base(id, name, surname)
        {
            this.specialization = specialization;
        }


        public List<TimeSlot> GetOccupiedTimeSlots(TimeSlot span)
        {
            List<TimeSlot> appointments = new List<TimeSlot>();
            string getInSpanQuery = "SELECT DateTime,Duration " +
                                    "FROM [MedicalAction] " +
                                    "WHERE DoctorID = @doctorId AND " +
                                    "DateTime BETWEEN @start AND @end " +
                                    "ORDER BY DateTime";
            DataTable retrieved = DatabaseConnection.GetInstance().CreateTableOfData(getInSpanQuery,
                ("@doctorId",ID),("@start",span.from),("@end",span.to));
            foreach(DataRow row in retrieved.Rows)
            {
                DateTime from = DateTime.Parse(row["DateTime"].ToString());
                appointments.Add(new TimeSlot(from, from.AddMinutes(Convert.ToInt32(row["Duration"]))));
            }

            return appointments;
        }


        public TimeSlot? TryUnderTwoHours(int duration = 15)
        {
            DateTime now = SecretaryService.GetNow();
            TimeSlot broadSpan = new TimeSlot(now.AddHours(-24), now.AddHours(24));
            List<TimeSlot> occupied = GetOccupiedTimeSlots(broadSpan);
            TimeSlot appointment = new TimeSlot(now, now.AddMinutes(duration));
            TimeSlot? firstAvailable = appointment.GetFirstUnoccupied(occupied);
            return firstAvailable;
        }

    }
}

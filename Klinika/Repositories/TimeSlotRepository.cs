using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using Klinika.Roles;

namespace Klinika.Repositories
{
    internal class TimeSlotRepository : Repository
    {
        private static TimeSlotRepository? instance;
        public static TimeSlotRepository GetInstance()
        {
            if (instance == null) instance = new TimeSlotRepository();
            return instance;
        }
        public List<TimeSlot> GetOccupiedTimeSlotsPerDoctor(TimeSlot span,int doctorID)
        {
            List<TimeSlot> appointments = new List<TimeSlot>();
            string getInSpanQuery = "SELECT DateTime,Duration " +
                                    "FROM [MedicalAction] " +
                                    "WHERE DoctorID = @doctorId AND " +
                                    "DateTime BETWEEN @start AND @end " +
                                    "ORDER BY DateTime";
            DataTable retrieved = database.CreateTableOfData(getInSpanQuery,
                ("@doctorId", doctorID), ("@start", span.from), ("@end", span.to));
            foreach (DataRow row in retrieved.Rows)
            {
                DateTime from = DateTime.Parse(row["DateTime"].ToString());
                appointments.Add(new TimeSlot(from, from.AddMinutes(Convert.ToInt32(row["Duration"]))));
            }

            return appointments;
        }
    }
}

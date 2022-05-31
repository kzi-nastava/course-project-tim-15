using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class VacationRequest
    {
        public enum Statuses { WAITING = 'W', ACCEPTED = 'A', DENIED = 'D' }
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
        public char Status { get; set; }
        public bool Emergency { get; set; }
        public string DenyReason { get; set; }
        public VacationRequest(int doctorID, DateTime fromDate, DateTime toDate,
            string reason, bool emergency)
        {
            ID = -1;
            DoctorID = doctorID;
            FromDate = fromDate;
            ToDate = toDate;
            Reason = reason;
            Status = (char)(emergency ? Statuses.ACCEPTED : Statuses.WAITING);
            Emergency = emergency;
            DenyReason = "";
        }

        public VacationRequest(int id, int doctorID, DateTime fromDate, DateTime toDate,
            string reason, char status, bool emergency, string denyReason)
        {
            ID = id;
            DoctorID = doctorID;
            FromDate = fromDate;
            ToDate = toDate;
            Reason = reason;
            Status = status;
            Emergency = emergency;
            DenyReason = denyReason;
        }
    }
}

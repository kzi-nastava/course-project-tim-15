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
        public int id { get; set; }
        public int doctorID { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string reason { get; set; }
        public char status { get; set; }
        public bool emergency { get; set; }
        public string denyReason { get; set; }
        public VacationRequest(int doctorID, DateTime fromDate, DateTime toDate,
            string reason, bool emergency)
        {
            id = -1;
            this.doctorID = doctorID;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.reason = reason;
            status = (char)(emergency ? Statuses.ACCEPTED : Statuses.WAITING);
            this.emergency = emergency;
            denyReason = "";
        }

        public VacationRequest(int id, int doctorID, DateTime fromDate, DateTime toDate,
            string reason, char status, bool emergency, string denyReason)
        {
            this.id = id;
            this.doctorID = doctorID;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.reason = reason;
            this.status = status;
            this.emergency = emergency;
            this.denyReason = denyReason;
        }
    }
}

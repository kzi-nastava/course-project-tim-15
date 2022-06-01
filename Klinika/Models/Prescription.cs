namespace Klinika.Models
{
    public class Prescription
    {
        public int patientID { get; set; }
        public int drugID { get; set; }
        public DateTime dateStarted { get; set; }
        public DateTime dateEnded { get; set; }
        public int interval { get; set; }
        public string? comment { get; set; }

        public Prescription() { }
        public Prescription(int patientID, int drugID, TimeSlot timeSlot, int interval, string comment)
        {
            this.patientID = patientID;
            this.drugID = drugID;
            dateStarted = timeSlot.from;
            dateEnded = timeSlot.to;
            this.interval = interval;
            this.comment = comment;
        }
    }
}

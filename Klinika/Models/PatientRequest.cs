namespace Klinika.Models
{
    internal class PatientRequest
    {
        public enum Types { Delete = 'D', Modify = 'M' }

        public int id { get; set; }
        public int patientID { get; set; }
        public int medicalActionID  { get; set; }
        public char type { get; set; }
        public string? description { get; set; }
        public bool approved { get; set; }

        public PatientRequest()
        {
            id = -1;
        }
        public PatientRequest(int patientID, int medicalActionID, Types type,
            string? description, bool approved)
        {
            id = -1;
            this.patientID = patientID;
            this.medicalActionID = medicalActionID;
            this.type = (char)type;
            this.description = description;
            this.approved = approved;
        }
    }
}

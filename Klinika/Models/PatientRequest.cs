namespace Klinika.Models
{
    internal class PatientRequest
    {
        public enum Types { Delete = 'D', Modify = 'M' }

        public int ID { get; set; }
        public int PatientID { get; set; }
        public int MedicalActionID  { get; set; }
        public char Type { get; set; }
        public string? Description { get; set; }
        public bool Approved { get; set; }

        public PatientRequest()
        {
            ID = -1;
        }
        public PatientRequest(int patientID, int medicalActionID, Types type,
            string? description, bool approved)
        {
            ID = -1;
            PatientID = patientID;
            MedicalActionID = medicalActionID;
            Type = (char)type;
            Description = description;
            Approved = approved;
        }
    }
}

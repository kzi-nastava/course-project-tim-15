namespace Klinika.Models
{
    public class Anamnesis
    {
        public int id { get; set; }
        public int medicalActionID { get; set; }
        public string? description { get; set; }
        public string? symptoms { get; set; }
        public string? conclusion { get; set; }

        public Anamnesis() { }

        public Anamnesis(int appointmentID, string description, string symptoms, string conclusion)
        {
            medicalActionID = appointmentID;
            this.description = description;
            this.symptoms = symptoms;
            this.conclusion = conclusion;
        }
    }
}

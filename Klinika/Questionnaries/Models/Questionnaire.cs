namespace Klinika.Questionnaries.Models
{
    internal class Questionnaire
    {
        public int id { get; set; }
        public int patientID { get; set; }
        public int? targetID { get; set; }
        public string comment { get; set; }
        public int appointmentID { get; set; }

        public Questionnaire(int patientID, string comment, int appointmentID = -1, int? targetID = null)
        {
            id = -1;
            this.patientID = patientID;
            this.targetID = targetID;
            this.comment = comment;
            this.appointmentID = appointmentID;
        }
    }
}



namespace Klinika.Models
{
    internal class Questionnaire
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int? TargetID { get; set; }
        public string Comment { get; set; }
        public int AppointmentID { get; set; }

        public Questionnaire(int patientID, string comment, int appointmentID = -1, int? targetID = null)
        {
            ID = -1;
            PatientID = patientID;
            TargetID = targetID;
            Comment = comment;
            AppointmentID = appointmentID;
        }
    }
}



namespace Klinika.Models
{
    internal class Questionnaire
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int TargetID { get; set; }
        public string Comment { get; set; }
        public int AppointmentID { get; set; }

        public Questionnaire(int id, int patientID, string comment)
        {
            ID = id;
            PatientID = patientID;
            TargetID = -1;
            Comment = comment;
            AppointmentID = -1;
        }
        public Questionnaire(int patientID, string comment, int appointmentID = -1, int targetID = -1)
        {
            ID = -1;
            PatientID = patientID;
            TargetID = targetID;
            Comment = comment;
            AppointmentID = appointmentID;
        }
    }
}

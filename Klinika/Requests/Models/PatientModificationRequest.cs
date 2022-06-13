namespace Klinika.Requests.Models

{
    internal class PatientModificationRequest
    {
        public int requestID { get; }
        public int oldDoctorID { get; }
        public int newDoctorID { get; }
        public DateTime oldAppointment { get; }
        public DateTime newAppointment { get; }

        public PatientModificationRequest(int requestID, int oldDoctorID, DateTime oldAppointment, string changesMadeDescription)
        {
            this.requestID = requestID;
            this.oldDoctorID = oldDoctorID;
            this.oldAppointment = oldAppointment;
            string[] tokens = changesMadeDescription.Split(';');
            newAppointment = DateTime.Parse(tokens[0].Split('=')[1]);
            newDoctorID = Convert.ToInt32(tokens[1].Split('=')[1]);
        }


    }
}

namespace Klinika.Models

{
    internal class PatientModificationRequest
    {
        public int oldDoctorID { get; }
        public int newDoctorID { get; }
        public DateTime oldAppointment { get; }
        public DateTime newAppointment { get; }
        public string changesMadeDescription { get; }


        public PatientModificationRequest(int oldDoctorID,DateTime oldAppointment,string changesMadeDescription)
        {
            this.oldDoctorID = oldDoctorID;
            this.oldAppointment = oldAppointment;
            this.changesMadeDescription = changesMadeDescription;
            string[] tokens = changesMadeDescription.Split(';');
            newAppointment = DateTime.Parse(tokens[0].Split('=')[1]);
            newDoctorID = Convert.ToInt32(tokens[1].Split('=')[1]);
        }


    }
}

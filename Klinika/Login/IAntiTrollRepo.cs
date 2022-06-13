namespace Klinika.Login
{
    public interface IAntiTrollRepo
    {
        int GetScheduledAppointmentsCount(int ID);
        List<string> GetDescriptions(int patientID);
    }
}

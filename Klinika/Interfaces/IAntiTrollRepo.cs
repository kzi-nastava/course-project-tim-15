namespace Klinika.Interfaces
{
    public interface IAntiTrollRepo
    {
        int GetScheduledAppointmentsCount(int ID);
        List<string> GetDescriptions(int patientID);
    }
}

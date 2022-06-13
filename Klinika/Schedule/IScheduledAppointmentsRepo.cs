using Klinika.Appointments.Models;
using Klinika.Schedule.Models;
using static Klinika.Users.Models.User;

namespace Klinika.Schedule
{
    public interface IScheduledAppointmentsRepo
    {
        List<Appointment> GetAll();
        List<Appointment> GetAll(string requestedDate, int userID, RoleType role, int days = 1);
        List<TimeSlot> GetOccupiedTimeSlotsPerDoctor(TimeSlot span, int doctorID);
        List<Appointment> GetAll(int userID, RoleType role);
    }
}

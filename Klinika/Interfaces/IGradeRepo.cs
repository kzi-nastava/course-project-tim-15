
namespace Klinika.Interfaces
{
    internal interface IGradeRepo
    {
        double GetDoctorGrade(int doctorID);
        bool IsAppointmentGraded(int appointmentID);
    }
}

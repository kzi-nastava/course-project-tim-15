using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface IVacationRequestRepo
    {
        int Create(VacationRequest vacationRequest);
        List<VacationRequest> GetAll(int doctorID);
    }
}

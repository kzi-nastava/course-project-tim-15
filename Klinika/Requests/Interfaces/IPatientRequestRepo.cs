using Klinika.Requests.Models;

namespace Klinika.Requests.Interfaces
{
    public interface IPatientRequestRepo
    {
        public List<PatientRequest>? GetAll();
        public void Approve(int id);
        public void Deny(int id);
        public void Create(PatientRequest patientRequest);
    }
}

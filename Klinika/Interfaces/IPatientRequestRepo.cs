using Klinika.Models;

namespace Klinika.Interfaces
{
    public interface IPatientRequestRepo
    {
        public List<PatientRequest>? GetAll();
        public void Approve(int id);
        public void Deny(int id);
        public void Create(PatientRequest patientRequest);
    }
}

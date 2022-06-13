using Klinika.Users.Models;

namespace Klinika.Users.Interfaces
{
    public interface IPatientRepo
    {
        public List<Patient> GetAll();
        public Patient GetSingle(int id);
        public void Modify(Patient patient);
        public void Delete(int id);
        public void Create(Patient newPatient);
        public int? GetIdByEmail(string email);
    }
}

using Klinika.Models;

namespace Klinika.Roles
{
    public class Doctor : User
    {
        public enum Filters { BY_NAME, BY_SURNAME, BY_SPECIALIZATION, NONE }

        public Specialization specialization { get; }
        public int officeID { get; }

        public Doctor(int id, string name, string surname, Specialization specialization, int officeID) : base(id, name, surname)
        {
            this.specialization = specialization;
            this.officeID = officeID;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Roles
{
    internal class Patient : User
    {
        public string jmbg { get; set; }
        public DateTime birthdate { get; set; }

        public char gender { get; set; }


        public Patient(
                        int id,
                        string jmbg,
                        string name,
                        string surname,
                        DateTime birthdate,
                        char gender,
                        string email,
                        string password) : base(id, name, surname, email, password)
        {
            this.jmbg = jmbg;
            this.birthdate = birthdate;
            this.gender = gender;
        }
    }
}

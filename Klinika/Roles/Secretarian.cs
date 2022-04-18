using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Roles
{
    internal class Secretarian : User
    {
        public Secretarian(string email, string password, string name, string surname, string jmbg, DateOnly birthdate,
              RoleType roleType) : base(email, password, name, surname, jmbg, birthdate, roleType)
        {
        }
    }
}

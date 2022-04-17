using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Roles
{
    internal class Secretarian : User
    {
        public Secretarian(string email, string password, RoleType role) : base(email, password, role)
        {

        }
    }
}

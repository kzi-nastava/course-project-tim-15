using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Roles
{
    internal class Doctor : User
    {
        #region [ --- VARIABLES --- ]
        #endregion

        #region [ --- CONSTRUCTORS --- ]
        public Doctor(string email, string password, string name, string surname, string jmbg, DateOnly birthdate, GenderEnum gender,
                      RoleType roleType) : base(email, password,name,surname,jmbg,birthdate, gender, roleType)
        {
        }
        #endregion
        
    }
}

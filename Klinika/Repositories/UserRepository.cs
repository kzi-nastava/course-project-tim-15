using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    internal class UserRepository
    {
        public static Dictionary<string, User> users { get; }

        
        private static UserRepository instance;
        private UserRepository()
        {

            //TODO read Users.json and fill in the dictionary according to role
            //Create new instance of classes inside Roles according to the role 
            //key is email, value is descendant of abstract class User (every role class in Roles folder)  
        }
        public static UserRepository Instance
        {
            get
            {
                if (instance == null) instance = new UserRepository();
                return instance;
            }
        }
    }
}

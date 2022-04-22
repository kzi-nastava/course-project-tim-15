
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Data;
using System.Data.SqlClient;

namespace Klinika.Repositories
{
    internal class UserRepository
    {
        public  Dictionary<string, User> users { get; }

        
        private static UserRepository? instance;
        private UserRepository()
        {
            users = new Dictionary<string, User>();
            string getUserCredentialsQuery = "SELECT Email, Password, UserType.Name as UserType, IsBlocked FROM [User] JOIN [UserType] ON [User].UserType = [UserType].ID";

            SqlCommand getUserCredentials = new SqlCommand(getUserCredentialsQuery, SQLConnection.GetInstance().databaseConnection);
            SQLConnection.GetInstance().databaseConnection.Open();
            using(SqlDataReader reader = getUserCredentials.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User(reader["Email"].ToString(),reader["Password"].ToString(),reader["UserType"].ToString(),Convert.ToBoolean(reader["IsBlocked"]));
                    users.TryAdd(user.Email, user);
                }
            }
            SQLConnection.GetInstance().databaseConnection.Close();

        }
        public static UserRepository GetInstance()
        {
                if (instance == null) instance = new UserRepository();
                return instance;
        }
    }
}

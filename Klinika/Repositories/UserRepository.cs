
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
        public Dictionary<string, User> users { get; }


        private static UserRepository? singletonInstance;
        private UserRepository()
        {
            users = new Dictionary<string, User>();
            string getCredentialsQuery = "SELECT Email, Password, UserType.Name as UserType, IsBlocked FROM [User] JOIN [UserType] ON [User].UserType = [UserType].ID WHERE [User].IsDeleted = 0";
            try
            {
                SqlCommand getCredentials = new SqlCommand(getCredentialsQuery, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getCredentials.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        User user = new User(retrieved["Email"].ToString(), retrieved["Password"].ToString(), retrieved["UserType"].ToString(), Convert.ToBoolean(retrieved["IsBlocked"]));
                        users.TryAdd(user.Email, user);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static UserRepository GetInstance()
        {
            if (singletonInstance == null) singletonInstance = new UserRepository();
            return singletonInstance;
        }

    }
}

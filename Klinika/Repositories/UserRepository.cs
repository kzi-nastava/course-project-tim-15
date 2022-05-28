
using Klinika.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Data;
using System.Data.SqlClient;
using System.Data;

namespace Klinika.Repositories
{
    internal class UserRepository
    {
        public Dictionary<string, User> users { get; }
        public List<User> Users { get; }

        private static UserRepository? instance;

        public static UserRepository GetInstance()
        {
            if (instance == null) instance = new UserRepository();
            return instance;
        }

        private UserRepository()
        {
            users = new Dictionary<string, User>();
            Users = new List<User>();
            string getCredentialsQuery = "SELECT [User].ID, [User].Name, [User].Surname, " +
                "Email, Password, UserType.Name as UserType, IsBlocked " +
                "FROM [User] " +
                "JOIN [UserType] ON [User].UserType = [UserType].ID " +
                "WHERE [User].IsDeleted = 0";

            DataTable allUsers = DatabaseConnection.GetInstance().CreateTableOfData(getCredentialsQuery);
            foreach (DataRow row in allUsers.Rows)
            {
                User user = new User(Convert.ToInt32(row["ID"]),
                                     row["Name"].ToString(),
                                     row["Surname"].ToString(),
                                     row["Email"].ToString(),
                                     row["Password"].ToString(),
                                     row["UserType"].ToString(),
                                     Convert.ToBoolean(row["IsBlocked"]));
                users.TryAdd(user.Email, user);
                Users.Add(user);
            }

        }

        public static User[] GetPatients()
        {
            return GetInstance().Users.Where(x => x.Role.ToUpper() == User.RoleType.PATIENT.ToString()).ToArray();
        }

        public static List<User> GetDoctors()
        {
             return GetInstance().Users.Where(x => x.Role.ToUpper() == User.RoleType.DOCTOR.ToString()).ToList();
        }

        public static User? GetDoctor(int ID)
        {
            return GetInstance().Users.Where(x => x.ID == ID).FirstOrDefault();
        }
    }
}

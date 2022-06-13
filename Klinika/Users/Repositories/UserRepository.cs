using Klinika.Core;
using Klinika.Users.Interfaces;
using Klinika.Users.Models;
using System.Data;

namespace Klinika.Users.Repositories
{
    internal class UserRepository : Repository, IUserRepo
    {
        public Dictionary<string, User> users { get; }
        public List<User> Users { get; }

        public UserRepository()
        {
            users = new Dictionary<string, User>();
            Users = new List<User>();
            string getCredentialsQuery = "SELECT [User].ID, [User].Name, [User].Surname, " +
                "Email, Password, UserType.Name as UserType, IsBlocked " +
                "FROM [User] " +
                "JOIN [UserType] ON [User].UserType = [UserType].ID " +
                "WHERE [User].IsDeleted = 0";

            DataTable allUsers = database.CreateTableOfData(getCredentialsQuery);
            foreach (DataRow row in allUsers.Rows)
            {
                User user = new User(Convert.ToInt32(row["ID"]),
                                     row["Name"].ToString(),
                                     row["Surname"].ToString(),
                                     row["Email"].ToString(),
                                     row["Password"].ToString(),
                                     row["UserType"].ToString(),
                                     Convert.ToBoolean(row["IsBlocked"]));
                users.TryAdd(user.email, user);
                Users.Add(user);
            }

        }

        public User[] GetPatients()
        {
            return Users.Where(x => x.role.ToUpper() == User.RoleType.PATIENT.ToString()).ToArray();
        }

        public List<User> GetDoctors()
        {
            return Users.Where(x => x.role.ToUpper() == User.RoleType.DOCTOR.ToString()).ToList();
        }

        public User? GetSingle(int ID)
        {
            return Users.Where(x => x.id == ID).FirstOrDefault();
        }

        public void Block(int id, string whoBlocked)
        {
            string blockQuery = "UPDATE [User] SET " +
                "IsBlocked = 1, " +
                "WhoBlocked = @WhoBlocked " +
                "WHERE ID = @ID";

            database.ExecuteNonQueryCommand(
                blockQuery, ("@WhoBlocked", whoBlocked), ("@ID", id));
        }

        public void Unblock(int id)
        {
            string unblockQuery = "UPDATE [User] SET IsBlocked = 0, WhoBlocked = NULL " +
                                "WHERE ID = @ID";
            database.ExecuteNonQueryCommand(unblockQuery, ("@ID", id));
        }

        public User? GetByEmail(string email)
        {
            if (!users.ContainsKey(email)) return null;
            return users[email];
        }
    }
}

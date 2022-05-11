﻿
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
        public List<User> Users { get; }

        private static UserRepository? singletonInstance;
        private UserRepository()
        {
            users = new Dictionary<string, User>();
            Users = new List<User>();
            string getCredentialsQuery = "SELECT [User].ID, [User].Name, [User].Surname, " +
                "Email, Password, UserType.Name as UserType, IsBlocked " +
                "FROM [User] " +
                "JOIN [UserType] ON [User].UserType = [UserType].ID " +
                "WHERE [User].IsDeleted = 0";

            SqlDataReader retrieved = DatabaseConnection.GetInstance().ExecuteSelectCommand(getCredentialsQuery);
            DatabaseConnection.GetInstance().database.Open();

            while (retrieved.Read())
            {
                User user = new User(Convert.ToInt32(retrieved["ID"]),
                                     retrieved["Name"].ToString(),
                                     retrieved["Surname"].ToString(),
                                     retrieved["Email"].ToString(),
                                     retrieved["Password"].ToString(),
                                     retrieved["UserType"].ToString(),
                                     Convert.ToBoolean(retrieved["IsBlocked"]));
                users.TryAdd(user.Email, user);
                Users.Add(user);
            }
            DatabaseConnection.GetInstance().database.Close();

        }
        public static void Block(int ID)
        {
            string blockQuery = "UPDATE [User] SET " +
                "IsBlocked = @IsBlocked, " +
                "WhoBlocked = @WhoBlocked " +
                "WHERE ID = @ID";

            SqlCommand block = new SqlCommand(blockQuery, DatabaseConnection.GetInstance().database);
            block.Parameters.AddWithValue("@ID", ID);
            block.Parameters.AddWithValue("@IsBlocked", true);
            block.Parameters.AddWithValue("@WhoBlocked", "SYS");

            try
            {
                DatabaseConnection.GetInstance().database.Open();
                block.ExecuteNonQuery();
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

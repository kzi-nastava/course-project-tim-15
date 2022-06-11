﻿using Klinika.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Klinika.Data
{
    public class DatabaseConnection
    {
        public SqlConnection database { get; }
        private static DatabaseConnection? singletonInstance;

        private DatabaseConnection()
        {
            SqlConnectionStringBuilder credentials = new SqlConnectionStringBuilder();
            credentials.DataSource = "35.224.70.24";
            credentials.UserID = "sqlserver";
            credentials.Password = "UsiTim15#";
            credentials.InitialCatalog = "Clinic";

            database = new SqlConnection(credentials.ConnectionString);
        }

        public static DatabaseConnection GetInstance()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new DatabaseConnection();
            }
            return singletonInstance;
        }

        private SqlCommand CreateCommand(string query, params (string, object)[] commandParameters)
        {
            SqlCommand command = database.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            foreach ((string, object) parameter in commandParameters)
            {
                command.Parameters.AddWithValue(parameter.Item1, parameter.Item2);
            }
            return command;
        }

        public void ExecuteNonQueryCommand(string query, params (string,object)[] commandParameters)
        {
            try
            {
                database.Open();
                SqlCommand command = CreateCommand(query,commandParameters);
                command.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                throw new DatabaseConnectionException(error.Message);
            }
            finally
            {
                database.Close();
            }
        }


        public object? ExecuteNonQueryScalarCommand(string query, params (string, object)[] commandParameters)
        {
            object? value = null;
            try
            {
                database.Open();
                SqlCommand command = CreateCommand(query, commandParameters);
                value = command.ExecuteScalar();
            }
            catch (SqlException error)
            {
                throw new DatabaseConnectionException(error.Message);
            }
            finally
            {
                database.Close();
            }
            return value;
        }

        public DataTable CreateTableOfData(string query, params (string,object)[] commandParameters)
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = CreateCommand(query,commandParameters);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException error)
            {
                throw new DatabaseConnectionException(error.Message);
            }

            return table;
        }


        public List<object> ExecuteSelectCommand(string query, params (string, object)[] commandParameters)
        {
            List<object> retrieved = new List<object>();
            try
            {
                database.Open();
                SqlCommand command = CreateCommand(query, commandParameters);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object[] tempRow = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tempRow[i] = reader[i];
                        }
                        retrieved.Add(tempRow);
                    }
                }
            }
            catch (SqlException error)
            {
                throw new DatabaseConnectionException(error.Message);
            }
            finally
            {
                database.Close();
            }
            return retrieved;
        }

        public static T CheckNull<T>(object obj)
        {
            return obj == DBNull.Value ? default(T) : (T)obj;
        }
    }
}

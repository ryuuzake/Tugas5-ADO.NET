using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tugas5.Model;

namespace Tugas5.Config
{
    public class Database
    {
        private static string ConnectionURL = @"Data Source=DESKTOP-L4VGE4A\SQLEXPRESS01;Initial Catalog=todos;Integrated Security=True";
        private SqlConnection SqlConnection;

        public Database()
        {
            SqlConnection = CreateConnection();
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionURL);
        }

        public void OpenConnection()
        {
            SqlConnection.Open();
        }

        public void CloseConnection()
        {
            SqlConnection.Close();
        }

        public void RunSQLCommand(string sqlQuery)
        {
            OpenConnection();
            var command = SqlConnection.CreateCommand();
            command.CommandText = sqlQuery;
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public List<T> RunSQLQuery<T>(T obj, string sqlQuery) where T : IModel
        {
            var results = new List<T>();

            OpenConnection();
            var command = SqlConnection.CreateCommand();
            command.CommandText = sqlQuery;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add((T) obj.CreateModelFromReader(reader));
                }
            }
            CloseConnection();

            return results;
        }
    }
}

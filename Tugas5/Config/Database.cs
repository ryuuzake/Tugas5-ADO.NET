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
            SqlConnection = new SqlConnection(ConnectionURL);
        }

        public void RunSQLCommand(string sqlQuery)
        {
            SqlConnection.Open();
            var command = SqlConnection.CreateCommand();
            command.CommandText = sqlQuery;
            command.ExecuteNonQuery();
            SqlConnection.Close();
        }

        public List<T> RunSQLQuery<T>(T obj, string sqlQuery) where T : IModel
        {
            var results = new List<T>();

            SqlConnection.Open();
            var command = SqlConnection.CreateCommand();
            command.CommandText = sqlQuery;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add((T) obj.CreateModelFromReader(reader));
                }
            }
            SqlConnection.Close();

            return results;
        }
    }
}

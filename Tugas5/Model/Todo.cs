using System.Data.SqlClient;

namespace Tugas5.Model
{
    public class Todo : IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public IModel CreateModelFromReader(SqlDataReader reader)
        {
            return new Todo()
            {
                Id = int.Parse(reader[0].ToString()),
                Title = reader[1].ToString(),
                Body = reader[2].ToString(),
            };
        }
    }
}

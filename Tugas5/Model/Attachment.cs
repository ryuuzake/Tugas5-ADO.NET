using System.Data.SqlClient;

namespace Tugas5.Model
{
    public class Attachment : IModel
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public string Url { get; set; }

        public IModel CreateModelFromReader(SqlDataReader reader)
        {
            return new Attachment()
            {
                Id = int.Parse(reader[0].ToString()),
                TodoId = int.Parse(reader[1].ToString()),
                Url = reader[2].ToString(),
            };
        }
    }
}

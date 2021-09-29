using System.Data.SqlClient;

namespace Tugas5.Model
{
    public interface IModel
    {
        public IModel CreateModelFromReader(SqlDataReader reader);
    }
}

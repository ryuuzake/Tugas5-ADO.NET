using System.Collections.Generic;
using Tugas5.Config;
using Tugas5.Model;

namespace Tugas5.Repository
{
    public class AttachmentRepository
    {
        private readonly Database Database;

        public AttachmentRepository(Database database)
        {
            Database = database;
        }

        public void CreateAttachment(Attachment attachment)
        {
            var query = $"INSERT INTO attachments VALUES({attachment.Id}, {attachment.TodoId}, '{attachment.Url}')";
            Database.RunSQLCommand(query);
        }

        public void DeleteAttachment(int id)
        {
            var query = $"DELETE FROM attachments WHERE id = {id}";
            Database.RunSQLCommand(query);
        }

        public List<Attachment> FindAllAttachmentByTodoId(int todoId)
        {
            var query = $"SELECT * FROM attachments WHERE todo_id = {todoId}";

            var result = Database.RunSQLQuery(new Attachment(), query);

            return result;
        }

        public void UpdateAttachment(int id, Attachment attachment)
        {
            var query = $"UPDATE attachments SET id = {attachment.Id}, todo_id = '{attachment.TodoId}', url = '{attachment.Url}' WHERE id = {id}";
            Database.RunSQLCommand(query);
        }
    }
}

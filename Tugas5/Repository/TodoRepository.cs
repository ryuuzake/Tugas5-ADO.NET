using System;
using System.Collections.Generic;
using Tugas5.Config;
using Tugas5.Model;

namespace Tugas5.Repository
{
    public class TodoRepository
    {
        private readonly Database Database;

        public TodoRepository(Database database)
        {
            Database = database;
        }

        public void CreateTodo(Todo todo)
        {
            var query = $"INSERT INTO todos VALUES({todo.Id}, '{todo.Title}', '{todo.Body}')";
            Database.RunSQLCommand(query);
        }

        public void DeleteTodo(int id)
        {
            var query = $"DELETE FROM todos WHERE id = {id}";
            Database.RunSQLCommand(query);
        }

        public List<Todo> FindAllTodo()
        {
            var query = "SELECT id AS ID, title AS TITLE, body AS BODY FROM todos";

            var result = Database.RunSQLQuery(new Todo(), query);

            return result;
        }

        public void UpdateTodo(int id, Todo todo)
        {
            var query = $"UPDATE todos SET id = {todo.Id}, title = '{todo.Title}', body = '{todo.Body}' WHERE id = {id}";
            Database.RunSQLCommand(query);
        }
    }
}

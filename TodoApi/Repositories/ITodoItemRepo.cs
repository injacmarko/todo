using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ITodoItemRepo
    {
        IEnumerable<TodoItem> GetTodoItems();
        TodoItem GetTodoItem(long id);
        void AddTodoItem(TodoItem todoItem);
        void UpdateTodoItem(long id, TodoItem todoItem);
        void DeleteTodoItem(long id);
    }
}
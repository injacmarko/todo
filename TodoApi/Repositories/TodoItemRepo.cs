using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class TodoItemRepo : ITodoItemRepo
    {
        private readonly TodoContext _context;

        public TodoItemRepo(TodoContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem GetTodoItem(long id)
        {
            return _context.TodoItems.Find(id);
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            todoItem.Date = DateTime.Now.ToString("dd/MM/yyyy");
            
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
        }

        public void UpdateTodoItem(long id, TodoItem todoItem)
        {
            todoItem.Date = DateTime.Now.ToString("dd/MM/yyyy");

            _context.Entry(todoItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTodoItem(long id)
        {
            _context.TodoItems.Remove(_context.TodoItems.Find(id));
            _context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemRepo _todoItemRepo;

        public TodoItemsController(ITodoItemRepo todoItemRepo)
        {
            _todoItemRepo = todoItemRepo;
        }


        // GET: api/TodoItems
        [HttpGet]
        public IActionResult GetTodoItems()
        {
          if (_todoItemRepo.GetTodoItems == null)
          {
              return NotFound();
          }
            return Ok(_todoItemRepo.GetTodoItems());
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public IActionResult GetTodoItem(long id)
        {
          if (_todoItemRepo.GetTodoItem == null)
          {
              return NotFound();
          }
            var todoItem = _todoItemRepo.GetTodoItem(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _todoItemRepo.UpdateTodoItem(id, todoItem);

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTodoItem(TodoItem todoItem)
        {
            _todoItemRepo.AddTodoItem(todoItem);

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(long id)
        {
            if (_todoItemRepo.GetTodoItems == null)
            {
                return NotFound();
            }
            var todoItem = _todoItemRepo.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _todoItemRepo.DeleteTodoItem(id);

            return NoContent();
        }
    }
}

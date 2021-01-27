using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoListWebApi.Domain.Entities;
using TodoListWebApi.Domain.Interfaces;

namespace TodoListWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Todo>> GetTodo()
        {
            return await _todoRepository.GetAllTodosAsync();
        }

        [HttpPost]
        public async Task<Todo> AddTodo(Todo todo)
        {
            return await _todoRepository.AddTodoAsync(todo);
        }
        
        [HttpPut("{id}")]
        public async Task ToggleCompletedTodo(Todo todo)
        {
            await _todoRepository.ToggleCompletedTodoAsync(todo);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTodo(int id)
        {
            await _todoRepository.DeleteTodoAsync(id);
        }
    }
}
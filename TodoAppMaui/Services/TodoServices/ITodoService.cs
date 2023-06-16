using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.model;

namespace TodoAppMaui.Services.TodoServices
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetTodoList();
        void GetTodo(string identifier);
        Task UpdateTodo(Todo todo);
        Task<int> AddTodo(Todo todo);
        Task RemoveTodo(Todo todo);
    }
}

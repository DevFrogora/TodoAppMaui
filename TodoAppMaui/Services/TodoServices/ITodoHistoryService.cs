using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.model;

namespace TodoAppMaui.Services.TodoServices
{
    public interface ITodoHistoryService
    {
        Task<IEnumerable<Todo>> GetTodoList();
        Task<int> AddTodo(Todo todo);
        Task RemoveTodo(Todo todo);
    }
}

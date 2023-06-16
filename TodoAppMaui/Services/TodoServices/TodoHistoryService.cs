using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Api;
using TodoAppMaui.model;

namespace TodoAppMaui.Services.TodoServices
{
    public class TodoHistoryService : ITodoHistoryService
    {
        private readonly TodoHistoryApi todoHistoryApi;

        public TodoHistoryService(TodoHistoryApi todoApi)
        {
            this.todoHistoryApi = todoApi;
        }

        public Task<int> AddTodo(Todo todo)
        {
           return todoHistoryApi.AddTodo(todo);
        }

        public async Task RemoveTodo(Todo todo)
        {
           await todoHistoryApi.RemoveTodo(todo);
        }

        public async Task<IEnumerable<Todo>> GetTodoList()
        {
           return  await todoHistoryApi.GetTodoList();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoAppMaui.model;
using TodoAppMaui.Repos;
using TodoAppMaui.Services.TodoServices;

namespace TodoAppMaui.viewmodel
{
    public class TodoHistoryViewModel
    {
        private readonly ITodoService todoService;

        public TodoHistoryViewModel(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        public IEnumerable<Todo> todoList
        {
            get
            {
                return todoService.GetTodoList().Result;
            }
        }

    }
}

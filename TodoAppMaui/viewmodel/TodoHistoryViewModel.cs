using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class TodoHistoryViewModel : INotifyPropertyChanged
    {
        private readonly ITodoService todoService;

        public TodoHistoryViewModel(ITodoService todoService)
        {
            this.todoService = todoService;
            Refresh();
        }
        public IEnumerable<Todo> todoList { get; set; }

        internal virtual void OnAppearing() { }

        internal virtual void OnDisappearing() { }

        private void Refresh()
        {
            //todoService.GetTodoList().ConfigureAwait(false);
            Task.Run(async () => { todoList = await todoService.GetTodoList(); OnPropertyChanged(nameof(todoList)); });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}

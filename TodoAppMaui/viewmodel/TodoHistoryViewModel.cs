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
        private readonly ITodoHistoryService todoHistoryService;

        public TodoHistoryViewModel(ITodoHistoryService todoService)
        {
            this.todoHistoryService = todoService;
            Refresh();
        }
        public IEnumerable<Todo> todoHistoryList { get; set; }

        internal virtual void OnAppearing() { }

        internal virtual void OnDisappearing() { }

        private void Refresh()
        {
            Task.Run(async () => { todoHistoryList = await todoHistoryService.GetTodoList(); OnPropertyChanged(nameof(todoHistoryList)); });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}

using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoAppMaui.Cells;
using TodoAppMaui.model;
using TodoAppMaui.Repos;
using TodoAppMaui.Services.TodoServices;

namespace TodoAppMaui.viewmodel
{
    public class TodoHomeViewModel : INotifyPropertyChanged
    {
        public TodoHomeViewModel(ITodoService todoService)
        {
            this.todoService = todoService;
            OnRefreshTodo(null);
        }
        
        private readonly ITodoService todoService;
        public IEnumerable<Todo> todoList { get; set; }
        public bool boolIsTitleValid { get; set; }
        public bool boolIsDescriptionValid { get; set; }

        public ICommand OnAddTodoCommand => new Command(OnAddTodo);
        public ICommand OnEditTodoCommand => new Command(OnEditTodo);
        public ICommand OnShowEditPopUpCommand => new Command(OnShowEditPopUp);
        public ICommand OnShowDeletePopUpCommand => new Command(OnShowDeletePopUp);
        public ICommand OnCloseDeletePopupCommand => new Command(OnCloseDeletePopup);
        public ICommand OnDeleteTodoCommand => new Command(OnDeleteTodo);
        public ICommand OnTodoTaskCompletedCommand => new Command(OnTodoTaskCompleted);

        private async void OnTodoTaskCompleted(object obj)
        {
            var todo = (Todo)obj;
            todo.IsCompleted = !todo.IsCompleted;
            await todoService.UpdateTodo(todo);
            OnRefreshTodo(null);
        }

        public ICommand OnRefreshTodoCommand => new Command(OnRefreshTodo);

        TodoEditPopup todoEditPopup;
        TodoDeletePopup todoDeletePopup;
        public Todo tempTodo { get; set; } = new Todo();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnShowDeletePopUp(object obj)
        {
            this.tempTodo = ((Todo)obj).Clone();
            todoDeletePopup = new TodoDeletePopup();
            Application.Current.MainPage.ShowPopup(todoDeletePopup);
        }

        private async void OnDeleteTodo(object obj)
        {
            await todoService.RemoveTodo(tempTodo);
            OnRefreshTodo(null);
            this.tempTodo.Clear();
            todoDeletePopup.Close();
        }

        private void OnCloseDeletePopup(object obj)
        {
            todoDeletePopup.Close();
        }

        private void OnShowEditPopUp(object obj)
        {
            this.tempTodo = ((Todo)obj).Clone();
            todoEditPopup = new TodoEditPopup();
            Application.Current.MainPage.ShowPopup(todoEditPopup);
        }

        private async void OnEditTodo(object obj)
        {
            if (IsInputValid())
            {
                await todoService.UpdateTodo(tempTodo);
                OnRefreshTodo(null);
                this.tempTodo.Clear();
                todoEditPopup.Close();
            }
        }

        private async void OnAddTodo(object obj)
        {
            if (IsInputValid())
            {
                Todo item = new Todo
                {
                    Id = 1,
                    Datetime = DateTime.Now,
                    Title = tempTodo.Title,
                    Description = tempTodo.Description,
                    IsCompleted = false
                };
                await todoService.AddTodo(item);
                this.tempTodo.Clear();
                Application.Current.MainPage.DisplayAlert($"Added", $"Saved Todo Item", "ok");
                OnRefreshTodo(null);
            }
        }

        bool IsInputValid()
        {
            string strValidationError = boolIsDescriptionValid == true ? "" : "Error in Description";
            strValidationError += boolIsTitleValid == true ? "" : "\nError in title";

            if (string.IsNullOrEmpty(strValidationError))
            {
                return true;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert($"Error",
                        $" {strValidationError} ", "cancel");
                return false;
            }
        }

        void OnRefreshTodo(object obj)
        {
            Task.Run(async () => { todoList = await todoService.GetTodoList(); OnPropertyChanged(nameof(todoList)); });
        }

        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
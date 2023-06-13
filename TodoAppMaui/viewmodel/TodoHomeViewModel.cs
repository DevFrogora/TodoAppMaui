﻿using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
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
        }
        private readonly ITodoService todoService;
        public IEnumerable<Todo> todoList { get { return todoService.GetTodoList(); } set { } }

        public bool boolIsTitleValid { get; set; }
        public bool boolIsDescriptionValid { get; set; }

        public ICommand OnAddTodoCommand => new Command(OnAddTodo);
        public ICommand OnEditTodoCommand => new Command(OnEditTodo);
        public ICommand OnShowEditPopUpCommand => new Command(OnShowEditPopUp);
        public ICommand OnShowDeletePopUpCommand => new Command(OnShowDeletePopUp);
        public ICommand OnCloseDeletePopupCommand => new Command(OnCloseDeletePopup);
        public ICommand OnDeleteTodoCommand => new Command(OnDeleteTodo);

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

        private void OnDeleteTodo(object obj)
        {
            todoService.RemoveTodo(tempTodo);
            OnPropertyChanged(nameof(todoList));
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

        private void OnEditTodo(object obj)
        {
            if (IsInputValid())
            {
                todoService.UpdateTodo(tempTodo);
                this.tempTodo.Clear();
                todoEditPopup.Close();
            }
        }

        private void OnAddTodo(object obj)
        {
            if (IsInputValid())
            {
                Todo item = new Todo
                {
                    Id = 1,
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Title = tempTodo.Title,
                    Description = tempTodo.Description,
                    IsCompleted = false
                };
                todoService.AddTodo(item);
                OnPropertyChanged(nameof(todoList));
                this.tempTodo.Clear();
                Application.Current.MainPage.DisplayAlert($"Added", $"Saved Todo Item", "ok");
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
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Api;
using TodoAppMaui.model;

namespace TodoAppMaui.Services.TodoServices
{
    public class TodoService : ITodoService
    {
        private readonly TodoApi todoApi;

        public TodoService(TodoApi todoApi)
        {
            this.todoApi = todoApi;
        }

        public Task<int> AddTodo(Todo todo)
        {
           return todoApi.AddTodo(todo);
        }

        public async Task RemoveTodo(Todo todo)
        {
           await todoApi.RemoveTodo(todo);
        }

        public void GetTodo(string identifier)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Todo>> GetTodoList()
        {
           return  await todoApi.GetTodoList();
        }

        public async Task UpdateTodo(Todo todo)
        {
           await todoApi.UpdateTodo(todo);
        }
    }
}

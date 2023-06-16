using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.model;

namespace TodoAppMaui.Repos.InMemory
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        int primaryKey = 0; //Temp we will remove it later
        private List<Todo> todoList { get; set; }
        public InMemoryTodoRepository()
        {
            todoList = new List<Todo>();
            LoadData();
        }

        public async Task<IEnumerable<Todo>> GetTodoList()
        {
            return await Task.FromResult(todoList.ToList());
        }

        public Task<int> AddTodo(Todo item)
        {
            item.Id = primaryKey++;
            todoList.Add(item);
            return Task.FromResult(0);
        }

        public Task RemoveTodo(Todo item)
        {
            foreach (var todo in todoList)
            {
                if(todo.Id == item.Id)
                {
                    todoList.Remove(todo);
                        break;
                }
            }
            return Task.CompletedTask;
        }

        public Task UpdateTodo(Todo item)
        {
            foreach (var t in todoList.Where<Todo>(todo => todo.Id == item.Id))
            {
                 t.Title = item.Title; t.Description = item.Description;
            }
            return Task.CompletedTask;
        }

        public void LoadData()
        {
            var t1 = new Todo
            {
                Id = 1,
                Datetime = DateTime.Now,
                Title = "Morning Walk",
                Description = "To get Fresh air in the morning , let add more data so lol we can see Hahah",
                IsCompleted = false
            };
            var t2 = new Todo
            {
                Id = 2,
                Datetime = DateTime.Now,
                Title = "Evening Walk",
                Description = "To get rid of stress in the evening",
                IsCompleted = false
            };
            var t3 = new Todo
            {
                Id = 1,
                Datetime = DateTime.Now,
                Title = "Morning Walk",
                Description = "To get Fresh air in the morning , let add more data so lol we can see Hahah",
                IsCompleted = false
            };
            var t4 = new Todo
            {
                Id = 2,
                Datetime = DateTime.Now,
                Title = "Evening Walk",
                Description = "To get rid of stress in the evening",
                IsCompleted = false
            };
            var t5 = new Todo
            {
                Id = 1,
                Datetime = DateTime.Now,
                Title = "Morning Walk",
                Description = "To get Fresh air in the morning , let add more data so lol we can see Hahah",
                IsCompleted = false
            };
            var t6 = new Todo
            {
                Id = 2,
                Datetime = DateTime.Now,
                Title = "Evening Walk",
                Description = "To get rid of stress in the evening",
                IsCompleted = false
            };
            var t7 = new Todo
            {
                Id = 1,
                Datetime = DateTime.Now,
                Title = "Morning Walk",
                Description = "To get Fresh air in the morning , let add more data so lol we can see Hahah",
                IsCompleted = false
            };
            var t8 = new Todo
            {
                Id = 2,
                Datetime = DateTime.Now,
                Title = "Evening Walk",
                Description = "To get rid of stress in the evening",
                IsCompleted = false
            };
            AddTodo(t1);
            AddTodo(t2);
            AddTodo(t3);
            AddTodo(t4);
            AddTodo(t5);
            AddTodo(t6);
            AddTodo(t7);
            AddTodo(t8);
            AddTodo(t8);
            AddTodo(t8);
            AddTodo(t8);
        }

    }
}

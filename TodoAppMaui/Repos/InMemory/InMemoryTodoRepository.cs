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

        public IEnumerable<Todo> GetTodoList()
        {
            return todoList.ToList();
        }

        public void AddTodo(Todo item)
        {
            item.Id = primaryKey++;
            todoList.Add(item);
        }

        public void RemoveTodo(Todo item)
        {
            foreach (var todo in todoList)
            {
                if(todo.Id == item.Id)
                {
                    todoList.Remove(todo);
                        break;
                }
            }
        }

        public void UpdateTodo(Todo item)
        {
            foreach (var t in todoList.Where<Todo>(todo => todo.Id == item.Id))
            {
                 t.Title = item.Title; t.Description = item.Description;
            }
        }

        public void LoadData()
        {
            var t1 = new Todo
            {
                Id = 1,
                Date = new DateOnly(2021, 5, 31),
                Title = "Morning Walk",
                Description = "To get Fresh air in the morning",
                IsCompleted = false
            };
            var t2 = new Todo
            {
                Id = 2,
                Date = new DateOnly(2021, 5, 31),
                Title = "Evening Walk",
                Description = "To get rid of stress in the evening",
                IsCompleted = false
            };
            AddTodo(t1);
            AddTodo(t2);
        }

    }
}

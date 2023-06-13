using TodoAppMaui.model;

namespace TodoAppMaui.Repos
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodoList();
        void AddTodo(Todo item);
        void RemoveTodo(Todo item);
        void UpdateTodo(Todo item);
    }
}

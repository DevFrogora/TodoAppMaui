using TodoAppMaui.model;

namespace TodoAppMaui.Repos
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodoList();
        Task<int> AddTodo(Todo item);
        Task RemoveTodo(Todo item);
        Task UpdateTodo(Todo item);
    }
}

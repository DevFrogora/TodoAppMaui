using TodoAppMaui.model;

namespace TodoAppMaui.Repos
{
    public interface ITodoHistoryRepository
    {
        Task<IEnumerable<Todo>> GetTodoList();
        Task<int> AddTodo(Todo item);
        Task RemoveTodo(Todo item);
    }
}

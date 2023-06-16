using TodoAppMaui.model;
using TodoAppMaui.Repos;

namespace TodoAppMaui.Api;
public class TodoHistoryApi
{
    private readonly ITodoHistoryRepository todoHistoryRepository;

    public TodoHistoryApi(ITodoHistoryRepository todoRepository)
    {
        this.todoHistoryRepository = todoRepository;
    }

    public async Task<IEnumerable<Todo>> GetTodoList()
    {
        return await todoHistoryRepository.GetTodoList();
    }

    public Task<int> AddTodo(Todo item)
    {
        return todoHistoryRepository.AddTodo(item);
    }

    public async Task RemoveTodo(Todo item)
    {
        await todoHistoryRepository.RemoveTodo(item);
    }

}

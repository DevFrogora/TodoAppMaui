using System.ComponentModel.DataAnnotations;
using TodoAppMaui.model;
using TodoAppMaui.Repos;

namespace TodoAppMaui.Api;
public class TodoApi
{
    private readonly ITodoRepository todoRepository;

    public TodoApi(ITodoRepository todoRepository)
    {
        this.todoRepository = todoRepository;
    }

    public async Task<IEnumerable<Todo>> GetTodoList()
    {
        return await todoRepository.GetTodoList();
    }

    public Task<int> AddTodo(Todo item)
    {
        // do validation , if validation is not valid throw error
        ValidationContext context = new ValidationContext(item, null, null);
        var validationResults = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(item, context, validationResults, true);
        if (valid)
        {
          return todoRepository.AddTodo(item);
        }
        else
        {
            string errorStr="";
            foreach (ValidationResult validationResult in validationResults)
            {
                errorStr = validationResult.ErrorMessage;
            }
            throw new Exception($"{errorStr}");
        }
    }

    public async Task RemoveTodo(Todo item)
    {
        await todoRepository.RemoveTodo(item);
    }

    public async Task UpdateTodo(Todo item)
    {
        await todoRepository.UpdateTodo(item);
    }
}

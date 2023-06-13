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

    public IEnumerable<Todo> GetTodoList()
    {
        return todoRepository.GetTodoList();
    }

    public void AddTodo(Todo item)
    {
        // do validation , if validation is not valid throw error
        ValidationContext context = new ValidationContext(item, null, null);
        var validationResults = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(item, context, validationResults, true);
        if (valid)
        {
            todoRepository.AddTodo(item);
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

    public void RemoveTodo(Todo item)
    {
        todoRepository.RemoveTodo(item);
    }

    public void UpdateTodo(Todo item)
    {
        todoRepository.UpdateTodo(item);
    }
}

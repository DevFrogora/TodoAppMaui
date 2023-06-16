using AutoMapper;
using TodoAppMaui.Domainmodel;
using TodoAppMaui.model;

namespace TodoAppMaui.Repos.SqlLite
{
    public class SqlLiteTodoRepository : ITodoRepository
    {
        private readonly SqliteDatabaseContext dbContext;
        Mapper mapper;
        public SqlLiteTodoRepository(SqliteDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            mapper = AutoMapperConfig.InitializeAutomapper();
        }

        public async Task<int> AddTodo(Todo item)
        {
            //await dbContext.database.CreateTableAsync<TblTodo>();
            var todo = mapper.Map<TblTodo>(item);
            return await dbContext.database.InsertAsync(todo);
            //Console.WriteLine(output);
            //return Task.CompletedTask;
        }

        public async Task<IEnumerable<Todo>> GetTodoList()
        {
            var TblTodoList = await dbContext.database.Table<TblTodo>().ToListAsync();
            return mapper.Map<IEnumerable<Todo>>(TblTodoList);
        }

        public void RemoveTodo(Todo item)
        {
            var todo = mapper.Map<TblTodo>(item);
            dbContext.database.DeleteAsync(todo);
        }

        public void UpdateTodo(Todo item)
        {
            var todo = mapper.Map<TblTodo>(item);
            dbContext.database.UpdateAsync(todo);
        }
    }
}

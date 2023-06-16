using AutoMapper;
using TodoAppMaui.Domainmodel;
using TodoAppMaui.model;

namespace TodoAppMaui.Repos.SqlLite
{
    public class SqlLiteTodoHistoryRepository : ITodoHistoryRepository
    {
        private readonly SqliteDatabaseContext dbContext;
        Mapper mapper;
        public SqlLiteTodoHistoryRepository(SqliteDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            mapper = AutoMapperConfig.InitializeAutomapper();
        }

        public async Task<int> AddTodo(Todo item)
        {
            var todo = mapper.Map<TblTodo>(item);
            return await dbContext.database.InsertAsync(todo);
        }

        public async Task<IEnumerable<Todo>> GetTodoList()
        {
            var TblTodoList = await dbContext.database.Table<TblTodo>().ToListAsync();
            return mapper.Map<IEnumerable<Todo>>(TblTodoList);
        }

        public async Task RemoveTodo(Todo item)
        {
            var todo = mapper.Map<TblTodo>(item);
            await dbContext.database.DeleteAsync(todo);
        }

    }
}

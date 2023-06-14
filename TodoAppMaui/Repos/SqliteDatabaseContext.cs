using SQLite;
using TodoAppMaui.Domainmodel;

namespace TodoAppMaui.Repos
{
    public class SqliteDatabaseContext
    {
        public readonly SQLiteAsyncConnection database;
        public SqliteDatabaseContext(string dbPath )
        {
            database = new SQLiteAsyncConnection( dbPath );
            database.CreateTableAsync<TblTodo>();
        }



        public Task<List<TblTodo>> GetTodoAsync() {
            return database.Table<TblTodo>().ToListAsync();
        }

        public Task<int> SaveTodoASync(TblTodo todo)
        {
            //database.GetConnection();
            return database.InsertAsync(todo);
        }
    }
}

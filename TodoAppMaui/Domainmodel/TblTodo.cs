using SQLite;

namespace TodoAppMaui.Domainmodel;
public class TblTodo
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    //public DateOnly Date { get; set; }
    //public TimeOnly Time { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public bool isCompleted { get; set; }

}

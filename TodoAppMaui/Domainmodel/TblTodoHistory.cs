using SQLite;

namespace TodoAppMaui.Domainmodel;
public class TblTodoHistory
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public DateTime dateTime { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public bool isCompleted { get; set; }

}

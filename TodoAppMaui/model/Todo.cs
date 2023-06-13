using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoAppMaui.model;

public class Todo : INotifyPropertyChanged
{

    [Required]
    int id;
    public int Id
    {
        get { return id; }
        set { id = value; OnPropertyChanged(nameof(Id)); }
    }
    [Required]
    DateOnly date;
    public DateOnly Date
    {
        get { return date; }
        set { date = value; OnPropertyChanged(nameof(Date)); }
    }

    [Required]
    TimeOnly time { get; set; }
    public TimeOnly Time
    {
        get { return time; }
        set { time = value; OnPropertyChanged(nameof(Time)); }
    }
    [Required]
    [StringLength(50, MinimumLength = 4, ErrorMessage = "* Part numbers must be between 4 and 50 character in length.")]
    string title;
    public string Title
    {
        get { return title; }
        set { title = value; OnPropertyChanged(nameof(Title)); }
    }
    [Required]
    string description;
    public string Description
    {
        get { return description; }
        set { description = value; OnPropertyChanged(nameof(Description)); }
    }
    [Required]
    bool isCompleted;
    public bool IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; OnPropertyChanged(nameof(IsCompleted)); }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public void Clear()
    {
        Title = String.Empty;
        Description = String.Empty;
        IsCompleted = false;
        Time = new TimeOnly();
        Id = 0;
        Date = new DateOnly();
    }

    public Todo Clone()
    {
        return this.MemberwiseClone() as Todo;
    }
}

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
    DateTime datetime;
    public DateTime Datetime
    {
        get { return datetime; }
        set { datetime = value; OnPropertyChanged(nameof(Datetime)); }
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
        Id = 0;
        Datetime = DateTime.Now;
    }

    public Todo Clone()
    {
        return this.MemberwiseClone() as Todo;
    }
}

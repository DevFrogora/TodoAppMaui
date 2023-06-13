using TodoAppMaui.viewmodel;

namespace TodoAppMaui.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
		InitializeComponent();
        BindingContext = MauiProgram.GetService<TodoHomeViewModel>();
    }
}
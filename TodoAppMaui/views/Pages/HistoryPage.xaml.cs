using TodoAppMaui.model;
using TodoAppMaui.Repos;
using TodoAppMaui.viewmodel;

namespace TodoAppMaui.Pages;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
	{
		InitializeComponent();
        BindingContext = MauiProgram.GetService<TodoHistoryViewModel>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as TodoHistoryViewModel).OnAppearing();
    }
}
using TodoAppMaui.viewmodel;

namespace TodoAppMaui.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		BindingContext = MauiProgram.GetService<TodoSettingViewModel>(); ;
	}

	private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
	{
		TodoSettingViewModel todoSettingViewModel = ((SwitchCell)sender).BindingContext as TodoSettingViewModel;
		todoSettingViewModel.ToggleCommand.Execute(e.Value);
    }
}
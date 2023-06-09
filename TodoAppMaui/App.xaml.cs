using TodoAppMaui.Pages.MenuPage;

namespace TodoAppMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new FlyoutPageNavigation();
	}
}

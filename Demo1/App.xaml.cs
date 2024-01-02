using Demo1.Services.Navigation;

namespace Demo1;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
		InitializeComponent();

		MainPage = new AppShell(navigationService);
	}
}


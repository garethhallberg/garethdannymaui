using Demo1.Services.Navigation;

namespace Demo1;

public partial class AppShell : Shell
{
	private readonly INavigationService _navigationService;

	public AppShell(INavigationService navigationService)
	{
		_navigationService = navigationService;
		AppShell.InitializeRouting();
		InitializeComponent();
	}

	protected override async void OnHandlerChanged()
	{
		base.OnHandlerChanged();

		if (Handler is not null) {
			await _navigationService.InitializeAsync();
		}
	}

	// protected override async void OnParentSet()
	// {
	// 	base.OnParentSet();

	// 	if (Parent is not null) {
	// 		await _navigationService.InitializeAsync();
	// 	}
	// }

	private static void InitializeRouting()
	{
		Routing.RegisterRoute("//MainPage", typeof(MainPage));
		Routing.RegisterRoute("//Page2", typeof(Page2));
		Routing.RegisterRoute("//Page3", typeof(Page3));
	}
}


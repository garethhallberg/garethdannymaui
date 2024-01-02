using Demo1.Services.Settings;

namespace Demo1.Services.Navigation;

public class DemoNavigationService : INavigationService
{

    private readonly ISettingsService _settingsService;
    public DemoNavigationService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public Task InitializeAsync() =>
        NavigateToAsync(
            string.IsNullOrEmpty(_settingsService.AuthAccessToken)
            ? "//Page2"
            : "//MainPage"
        );
    
        
    

    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
    {
        var shellNavigation = new ShellNavigationState(route);
        Console.WriteLine("NavigateToAsync");
        return routeParameters != null
            ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
            : Shell.Current.GoToAsync(shellNavigation);
    }

    public Task PopAsync() =>
        Shell.Current.GoToAsync("..");
    
}
using Demo1.Services;
using Microsoft.Extensions.Logging;

using Demo1.Services.Settings;
using Demo1.Services.Navigation;

namespace Demo1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterAppServices()
			.RegisterViews();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}


	public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
		mauiAppBuilder.Services.AddSingleton<INavigationService, DemoNavigationService>();
		return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{
		Console.WriteLine("RegisterViews");
		mauiAppBuilder.Services.AddTransient<MainPage>();
		return mauiAppBuilder;
	}

}


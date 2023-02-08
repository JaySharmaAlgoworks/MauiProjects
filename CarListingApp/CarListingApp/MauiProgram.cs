using Microsoft.Extensions.Logging;
using CarListingApp.Services;
using CarListingApp.ViewModels;
using CarListingApp.Models;
using CarListingApp.Views;

namespace CarListingApp;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<CarService>();
        builder.Services.AddSingleton<CarListViewModel>();
        builder.Services.AddTransient<CarDetailPageViewModel>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<CarDetailPage>();
        return builder.Build();
	}
}


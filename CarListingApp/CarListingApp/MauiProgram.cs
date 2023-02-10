using Microsoft.Extensions.Logging;
using CarListingApp.Services;
using CarListingApp.ViewModels;
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

		#region Services
        builder.Services.AddSingleton<CarService>();
        #endregion

        #region ViewModels
        builder.Services.AddSingleton<CarListViewModel>();
        builder.Services.AddTransient<CarDetailPageViewModel>();
        #endregion

        #region Pages
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<CarDetailPage>();
        #endregion


        return builder.Build();
	}
}


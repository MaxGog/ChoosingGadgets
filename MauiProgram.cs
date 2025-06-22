using ChoosingGadgets.Repositories;
using ChoosingGadgets.Services;
using ChoosingGadgets.ViewModels;
using ChoosingGadgets.Views;

using Microsoft.Extensions.Logging;

namespace ChoosingGadgets;

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

		builder.Services.AddSingleton<DeviceRepository>();
        builder.Services.AddSingleton<ParserService>();
        builder.Services.AddSingleton<BackgroundParserService>();
        
        builder.Services.AddSingleton<DevicesViewModel>();
        builder.Services.AddSingleton<DevicesPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

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

        RegisterServices(builder.Services);

        RegisterViewModels(builder.Services);

        RegisterPages(builder.Services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<DeviceRepository>();
        
        services.AddSingleton<ParserService>();
        services.AddSingleton<BackgroundParserService>();
    }

    private static void RegisterViewModels(IServiceCollection services)
    {
        services.AddSingleton<DevicesViewModel>();
        services.AddSingleton<SettingsViewModel>();
        
        services.AddTransient<ResultsViewModel>();
        services.AddTransient<ResultsPhonePage>();
        services.AddTransient<AddDeviceViewModel>();
        
    }

    private static void RegisterPages(IServiceCollection services)
    {
        services.AddSingleton<DevicesPage>();
        services.AddSingleton<SettingsPage>();
        services.AddSingleton<QuestionnairePage>();
        services.AddSingleton<QuestionnairePhonePage>();

        services.AddTransient<ResultsPage>();
        services.AddTransient<ResultsPhonePage>();
        services.AddTransient<AddDevicePage>();
    }
}
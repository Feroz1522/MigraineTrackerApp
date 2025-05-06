using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MigraineTrackerApp.DI;

namespace MigraineTrackerApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OSReg");
                    fonts.AddFont("OpensSans-Semibold.ttf", "OSSem");
                    fonts.AddFont("Poppins-Bold.ttf", "PBold");
                    fonts.AddFont("Poppins-Medium.ttf", "PMed");
                    fonts.AddFont("Poppins-SemiBold.ttf", "PSBold");
                });
            StartUp.Init();


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

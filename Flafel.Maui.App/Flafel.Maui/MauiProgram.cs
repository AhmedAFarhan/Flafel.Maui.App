using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using Flafel.Infrastructure;
using Flafel.Applications;
using Microsoft.Extensions.Configuration;
using Flafel.Maui.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Flafel.Applications.Contracts.UserContext;

namespace Flafel.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                    .ConfigureFonts(fonts =>
                    {
                        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    });

            // Add appsettings.json explicitly
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddApplicationServieces();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddMauiBlazorWebView();

			builder.Services.AddScoped<CustomAuthStateProvider>();
			builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
            builder.Services.AddScoped<IUserContext, UserContext>();

            builder.Services.AddAuthorizationCore();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            return app;
        }
    }
}

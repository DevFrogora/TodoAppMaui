using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoAppMaui.Api;
using TodoAppMaui.Pages;
using TodoAppMaui.Repos;
using TodoAppMaui.Repos.InMemory;
using TodoAppMaui.Services.TodoServices;
using TodoAppMaui.viewmodel;

namespace TodoAppMaui;

public static class MauiProgram
{
    public static TService GetService<TService>()
    => Service.GetService<TService>();
	public static IServiceProvider Service;
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<ITodoDbContext, TodoDbContext>();
        builder.Services.AddSingleton<ITodoService, TodoService>();
        builder.Services.AddSingleton<TodoApi>();
        builder.Services.AddSingleton<ITodoRepository,InMemoryTodoRepository>();

        builder.Services.AddSingleton<TodoHomeViewModel>();
        builder.Services.AddSingleton<TodoHistoryViewModel>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HistoryPage>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		var app = builder.Build();
		Service = app.Services;
        return app;
	}
}

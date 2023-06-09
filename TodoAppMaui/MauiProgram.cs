﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoAppMaui.Api;
using TodoAppMaui.Pages;
using TodoAppMaui.Repos;
using TodoAppMaui.Repos.InMemory;
using TodoAppMaui.Repos.SqlLite;
using TodoAppMaui.Services.Storage.Secure;
using TodoAppMaui.Services.Storage.SharedPreference;
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
		builder.Services.AddSingleton<SqliteDatabaseContext>(
            new SqliteDatabaseContext(Path.Combine(FileSystem.AppDataDirectory, "MyDatabase.db")));

        builder.Services.AddSingleton<ITodoRepository,SqlLiteTodoRepository>();
        builder.Services.AddSingleton<ITodoHistoryRepository, SqlLiteTodoHistoryRepository>();

        builder.Services.AddSingleton<ITodoService, TodoService>();
        builder.Services.AddSingleton<ITodoHistoryService, TodoHistoryService>();
        builder.Services.AddSingleton<TodoApi>();
        builder.Services.AddSingleton<TodoHistoryApi>();

        builder.Services.AddSingleton<ISecureStorageService,MauiSecureStorageService>();
        builder.Services.AddSingleton<ISharedPreferenceService,MauiSharedPreferenceService>();

        builder.Services.AddTransient<TodoHomeViewModel>();
        builder.Services.AddTransient<TodoHistoryViewModel>();
        builder.Services.AddSingleton<TodoSettingViewModel>();
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

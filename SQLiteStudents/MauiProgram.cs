using Microsoft.Extensions.DependencyInjection;
using SQLiteStudents.ViewModels;
using SQLiteStudents.Views;

namespace SQLiteStudents;

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
		// Services 


		// View Registration
		builder.Services.AddSingleton<StudentListPage>();

		// View Models
		builder.Services.AddSingleton<StudentListPageViewModel>();

		return builder.Build();
	}
}

using MauiTabs.Servises;
using MauiTabs.ViewModels;
using MauiTabs.Views;
using Microsoft.Extensions.Logging;

namespace MauiTabs;

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

		//Services
		builder.Services.AddSingleton<IDatabaseService, DatabaseService>();

		//Views Registration
		builder.Services.AddSingleton<StudentListPage>();
        builder.Services.AddSingleton<AddUpdateStudentDetail>();

        builder.Services.AddSingleton<SubjectListPage>();
        builder.Services.AddSingleton<AddUpdateSubjectDetail>();

        //View Models
        builder.Services.AddSingleton<StudentListPageViewModel>(); 
        builder.Services.AddSingleton<AddUpdateStudentDetailViewModel>();

        builder.Services.AddSingleton<SubjectListPageViewModel>();
        builder.Services.AddSingleton<AddUpdateSubjectDetailViewModel>();

        return builder.Build();
	}
}

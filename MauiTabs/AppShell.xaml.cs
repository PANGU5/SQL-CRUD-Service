using MauiTabs.Views;

namespace MauiTabs;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUpdateStudentDetail), typeof(AddUpdateStudentDetail));
        Routing.RegisterRoute(nameof(AddUpdateSubjectDetail), typeof(AddUpdateSubjectDetail));
    }
}

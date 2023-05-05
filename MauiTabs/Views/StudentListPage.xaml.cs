using MauiTabs.ViewModels;

namespace MauiTabs.Views;

public partial class StudentListPage : ContentPage
{
    protected StudentListPageViewModel _viewModel;
    public StudentListPage(StudentListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetStudentListCommand.Execute(null);
    }
}
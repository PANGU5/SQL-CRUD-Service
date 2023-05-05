using MauiTabs.ViewModels;
namespace MauiTabs.Views;

public partial class SubjectListPage : ContentPage
{
    protected SubjectListPageViewModel _viewModel;
    public SubjectListPage(SubjectListPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetSubjectListCommand.Execute(null);
    }
}
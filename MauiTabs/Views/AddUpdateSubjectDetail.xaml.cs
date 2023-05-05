using MauiTabs.ViewModels;

namespace MauiTabs.Views;

public partial class AddUpdateSubjectDetail : ContentPage
{
    public AddUpdateSubjectDetail(AddUpdateSubjectDetailViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
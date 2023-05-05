using MauiTabs.ViewModels;

namespace MauiTabs.Views;

public partial class AddUpdateStudentDetail : ContentPage
{
	public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
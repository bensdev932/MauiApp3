using MauiApp3.ViewModel; // <-- adjust to the real namespace

namespace MauiApp3;

public partial class DetailPage : ContentPage
{
	public DetailPage(MauiApp3.ViewModel.DetailViewModel vm) // <-- full namespace
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
using CarListingApp.ViewModels;

namespace CarListingApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(CarListViewModel carListViewModel)
	{
		InitializeComponent();
		BindingContext = carListViewModel;
	}

	
}



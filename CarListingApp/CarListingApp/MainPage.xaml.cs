using CarListingApp.ViewModels;

namespace CarListingApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(CarListViewModel carListViewModel)
	{
		InitializeComponent();
		BindingContext = carListViewModel;
		//How to use prefernces for storage
		//Preferences.Set("saveDetails", true);
		//var detailsaved = Preferences.Get("saveDetails", false);

		
	}

	
}



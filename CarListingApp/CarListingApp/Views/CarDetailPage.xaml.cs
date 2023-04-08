using CarListingApp.ViewModels;

namespace CarListingApp.Views;

public partial class CarDetailPage : ContentPage
{
	public CarDetailPage(CarDetailPageViewModel carDetailPageViewModel)
	{
		InitializeComponent();
		BindingContext = carDetailPageViewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}

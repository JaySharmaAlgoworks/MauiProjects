namespace MyFirstMauiApp;

public partial class LayoutExample : ContentPage
{
	public LayoutExample()
	{
		InitializeComponent();
		VStackLayout.Padding = DeviceInfo.Platform == DevicePlatform.iOS ? new Thickness(10, 20, 10, 20) : new Thickness(20);

    }
}

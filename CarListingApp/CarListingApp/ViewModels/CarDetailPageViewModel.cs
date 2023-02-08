using System;
using CarListingApp.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace CarListingApp.ViewModels
{
	[QueryProperty(nameof(Car),"Car")]
	public partial class CarDetailPageViewModel:BaseViewModel
	{
		[ObservableProperty]
		Car car;
		
	}
}


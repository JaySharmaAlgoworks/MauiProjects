using System;
using System.Collections.ObjectModel;
using CarListingApp.Services;
using CarListingApp.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Diagnostics;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using CarListingApp.Views;

namespace CarListingApp.ViewModels
{
	public partial class CarListViewModel:BaseViewModel
    {
		private readonly CarService carService;
		public ObservableCollection<Car> Cars { get; set; } = new();
		public CarListViewModel(CarService carService)
		{
			Title = "Car List";
			this.carService = carService;
		}
		[ObservableProperty]
         bool isRefreshing;
        [ICommand]
		async Task GetCarList()
		{
			if (IsLoading) return;
			try
			{
				IsLoading = true;
				if (Cars.Any()) Cars.Clear();

				var cars = carService.GetCars();

				foreach(var car in cars)
				{
					Cars.Add(car);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to get cars:{ex.Message}");
				await Shell.Current.DisplayAlert("Error", "failed to retrive list of cars", "Ok");
				
			}
			finally
			{
				IsLoading = false;
				IsRefreshing = false;
			}
		}
        [ICommand]
        async Task GetCarDetails(Car car)
		{
			if (car == null) return;
			await Shell.Current.GoToAsync(nameof(CarDetailPage), true, new Dictionary<string, object>
			{
				{ nameof(Car), car }
			});
		}

    }
}


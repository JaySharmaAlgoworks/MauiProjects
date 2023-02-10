using System;
using System.Collections.ObjectModel;
using CarListingApp.Services;
using CarListingApp.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Diagnostics;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using CarListingApp.Views;
using System.Text.Json;

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

				//Stored in fileSystem 
				/*string fileName = "carlist.json";
				var serializedList = JsonSerializer.Serialize(cars);
				File.WriteAllText(fileName, serializedList);

				var rawText=File.ReadAllText(fileName);
				var carsFromText = JsonSerializer.Deserialize<List<Car>>(rawText);
				string path = FileSystem.AppDataDirectory;
				string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);*/
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


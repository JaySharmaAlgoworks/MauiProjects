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
    public partial class CarListViewModel : BaseViewModel
    {
        public ObservableCollection<Car> Cars { get; set; } = new();

        public CarListViewModel()
        {
            Title = "Car List";
            GetCarList().Wait();
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string make;

        [ObservableProperty]
        string model;

        [ObservableProperty]
        string vin;

        [ICommand]

        async Task GetCarList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Cars.Any()) Cars.Clear();

                var cars = App.CarService.GetCars();

                foreach (var car in cars)
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

        async Task GetCarDetails(int id)
        {
            if (id == 0) return;
            await Shell.Current.GoToAsync($"{nameof(CarDetailPage)}?Id={id}", true);
        }

        [ICommand]

        async Task AddCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
            }
            var car = new Car
            {
                Make = Make,
                Model = Model,
                Vin = Vin
            };
            App.CarService.AddCar(car);
            await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");
            await GetCarList();
        }

        [ICommand]

        async Task DeleteCar(int id)
        {
            if (id == 0)
            {
                await Shell.Current.DisplayAlert("Invalid Record", "Please try again", "Ok");
                return;
            }
            var result = App.CarService.DeleteCar(id);
            if (result == 0)
            {
                await Shell.Current.DisplayAlert("Failed", "Please insert valid data", "Ok");

            }
            else
            {
                await Shell.Current.DisplayAlert("Deletion Successful", "Record Removed Successfully", "Ok");

            }
        }

    }
}


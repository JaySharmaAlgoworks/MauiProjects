using System;
using System.Web;
using CarListingApp.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace CarListingApp.ViewModels
{
	[QueryProperty(nameof(Id),nameof(Id))]
	public partial class CarDetailPageViewModel:BaseViewModel,IQueryAttributable
	{
		[ObservableProperty]
		Car car;

        [ObservableProperty]
        int id;
		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
			Car = App.CarService.GetCar(Id);
		}
    }
}


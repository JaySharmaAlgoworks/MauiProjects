﻿using CarListingApp.Views;

namespace CarListingApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(CarDetailPage), typeof(CarDetailPage));
	}

}


using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace CarListingApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotLoading))]
        bool isLoading;

        public bool IsNotLoading => !isLoading;
    }

    
}


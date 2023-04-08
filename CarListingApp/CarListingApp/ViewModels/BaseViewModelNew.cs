using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarListingApp.ViewModels
{
    public partial class BaseViewModelNew : INotifyPropertyChanged
    {
        #region Fields

        string _title;
        string _isBusy;
        #endregion

        #region Properties
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public string IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                    return;
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

}


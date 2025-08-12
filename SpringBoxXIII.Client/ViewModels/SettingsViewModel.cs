using CommunityToolkit.Mvvm.Input;
using SpringBoxXIII.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpringBoxXIII.Client.ViewModels
{
    public partial class SettingsViewModel(IApiService apiService) : INotifyPropertyChanged
    {
        private readonly IApiService _apiService = apiService;

        private string? _apiBaseAddress;
        public string ApiBaseAddress
        {
            get => _apiBaseAddress ?? "https://localhost:5106/";
            set
            {
                if (_apiBaseAddress != value)
                {
                    _apiBaseAddress = value;
                    OnPropertyChanged();
                }
            }
        }

        [RelayCommand]
        private void SetBaseAddress()
        {
            if (_apiBaseAddress is not null)
            {
                _apiService.SetBaseAddress(_apiBaseAddress);
            }

        }

        [RelayCommand]
        private void NavigateToMainPage()
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

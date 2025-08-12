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
    public partial class SettingsViewModel(IApiConfigService apiConfigService) : INotifyPropertyChanged
    {
        private readonly IApiConfigService _apiConfigService = apiConfigService;

        private string? _apiBaseAddress;
        public string? ApiBaseAddress
        {
            get => _apiBaseAddress;
            set
            {
                if (_apiBaseAddress != value && value != null)
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
                _apiConfigService.BaseAddress = _apiBaseAddress;
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

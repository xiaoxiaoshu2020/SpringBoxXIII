using CommunityToolkit.Mvvm.Input;
using SpringBoxXIII.Client.Services;
using SpringBoxXIII.Shared.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpringBoxXIII.Client.ViewModels
{
    public partial class LoginViewModel(IApiService apiService) : INotifyPropertyChanged
    {
        private readonly IApiService _apiService = apiService;

        private string? _userName;
        private string? _password;
        public string? UserName
        {
            get => _userName;
            set
            {
                if (_userName != value && value != null)
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string? Password
        {
            get => _password;
            set
            {
                if (_password != value && value != null)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
        [RelayCommand]
        public async Task Login()
        {
            string result = await _apiService.PostAsync("/api/Login", new LoginRequest { UserName = UserName, Password = Password });
            await Shell.Current.DisplayAlert("登录结果", result, "OK");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

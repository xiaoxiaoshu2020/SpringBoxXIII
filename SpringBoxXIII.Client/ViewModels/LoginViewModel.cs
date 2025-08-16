using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpringBoxXIII.Client.ViewModels
{
    public partial class LoginViewModel : INotifyPropertyChanged
    {
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
        public void Login()
        {
            // Implement login logic here
            // For example, validate credentials and navigate to another page
            if (UserName == "admin" && Password == "password")
            {
                // Navigate to main page or show success message
                Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                // Show error message
                Application.Current?.MainPage?.DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

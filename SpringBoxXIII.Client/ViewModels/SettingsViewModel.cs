using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringBoxXIII.Client.ViewModels
{
    public partial class SettingsViewModel
    {
        [RelayCommand]
        private void NavigateToMainPage()
        {
            Shell.Current.GoToAsync("//MainPage");
        }
    }
}

using CommunityToolkit.Mvvm.Messaging;
using SpringBoxXIII.Client.Models.Messages;
using SpringBoxXIII.Client.Services;
using SpringBoxXIII.Shared.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SpringBoxXIII.Client.ViewModels
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        private readonly IApiService _apiService;

        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CountText));
                    OnPropertyChanged(nameof(ButtonText));
                }
            }
        }
        public ICommand IncrementCommand { get; }
        public ICommand GetDataCommand { get; }
        public ICommand PostDataCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        private void IncrementCount()
        {
            WeakReferenceMessenger.Default.Send(new StartAnimationMessage
            {
                TargetElementName = "Img"
            });
            Count++;
        }
        private async void GetData()
        {
            string json = await _apiService.GetAsync("/api/Hello");
            WeakReferenceMessenger.Default.Send(new TestServerMessage
            {
                Message = json
            });
        }
        private async void PostData()
        {
            string json = await _apiService.PostAsync("/api/Hello",new User { Id = 1, Name="Vivactil"});
            WeakReferenceMessenger.Default.Send(new TestServerMessage
            {
                Message = json
            });
        }
        private async void NavigateToSettings()
        {
            await Shell.Current.GoToAsync("//SettingsPage");
        }
        public MainViewModel(IApiService apiService)
        {
            _apiService = apiService;
            IncrementCommand = new Command(IncrementCount);
            GetDataCommand = new Command(GetData);
            PostDataCommand = new Command(PostData);
            NavigateToSettingsCommand = new Command(NavigateToSettings);
        }

        public string CountText => "祝刘春冶和吴宇轩百年好合\n" + $"祝贺次数: {Count}";
        public string ButtonText => Count == 0 ? "点击我" : $"点击了 {Count} 次";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
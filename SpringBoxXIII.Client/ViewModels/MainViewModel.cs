using CommunityToolkit.Mvvm.Input;
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

        private IDispatcherTimer? _timer;

        public MainViewModel(IApiService apiService)
        {
            _apiService = apiService;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            if (Application.Current?.Dispatcher == null)
            {
                throw new InvalidOperationException("Application.Current 或 Dispatcher 为空，无法初始化定时器。");
            }
            _timer = Application.Current.Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += async (s, e) => await PostDataAsync();
            _timer.Start();
        }

        async Task PostDataAsync()
        { 
            await _apiService.PostAsync("/api/Hello", new User { Id = 1, Name = Count.ToString() });
        }

        [RelayCommand]
        private void IncreaseCount()
        {
            WeakReferenceMessenger.Default.Send(new StartAnimationMessage
            {
                TargetElementName = "Img"
            });
            Count++;
        }
        [RelayCommand]
        private async Task GetData()
        {
            string json = await _apiService.GetAsync("/api/Hello");
            WeakReferenceMessenger.Default.Send(new TestServerMessage
            {
                Message = json
            });
        }

        [RelayCommand]
        private async Task PostData()
        {
            string json = await _apiService.PostAsync("/api/Hello",new User { Id = 1, Name="Vivactil"});
            WeakReferenceMessenger.Default.Send(new TestServerMessage
            {
                Message = json
            });
        }
        [RelayCommand]
        private async Task NavigateToSettings()
        {
            await Shell.Current.GoToAsync("//SettingsPage");
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
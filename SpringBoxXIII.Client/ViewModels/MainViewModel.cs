using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SpringBoxXIII.Client.Models.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpringBoxXIII.Client.ViewModels
{
    internal partial class MainViewModel : INotifyPropertyChanged
    {
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
        private void IncrementCount()
        {
            WeakReferenceMessenger.Default.Send(new StartAnimationMessage
            {
                TargetElementName = "Img"
            });
            Count++;
        }
        public MainViewModel()
        {
            IncrementCommand = new Command(IncrementCount);
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
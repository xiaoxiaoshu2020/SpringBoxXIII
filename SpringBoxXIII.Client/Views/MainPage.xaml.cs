using CommunityToolkit.Mvvm.Messaging;
using SpringBoxXIII.Client.ViewModels;
using SpringBoxXIII.Client.Models.Messages;

namespace SpringBoxXIII.Client.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<StartAnimationMessage>(this, (r, m) =>
            {
                if (m.TargetElementName == "Img")
                {
                    Dispatcher.Dispatch(async () =>
                    {
                        await Img.ScaleTo(1.2, 200);
                        await Img.ScaleTo(1.0, 200);
                    });
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // 取消注册消息接收器
            WeakReferenceMessenger.Default.Unregister<StartAnimationMessage>(this);
        }
    }
}
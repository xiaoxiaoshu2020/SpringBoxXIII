using CommunityToolkit.Mvvm.Messaging;
using SpringBoxXIII.Client.DataModels.Messages;
using SpringBoxXIII.Client.ViewModels;

namespace SpringBoxXIII.Client.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            WeakReferenceMessenger.Default.Register<StartAnimationMessage>(this, (r, m) =>
            {
                if (m.TargetElementName == "Img")
                {
                    Dispatcher.Dispatch(async () =>
                    {
                        await Img.ScaleTo(1.2, 200);
                        await Img.RotateTo(360, 200);
                        await Img.ScaleTo(1.0, 200);
                        await Img.RotateTo(0, 0);
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
using SpringBoxXIII.Client.ViewModels;

namespace SpringBoxXIII.Client.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}
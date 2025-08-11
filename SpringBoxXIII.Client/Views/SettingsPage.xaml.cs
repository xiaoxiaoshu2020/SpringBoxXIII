namespace SpringBoxXIII.Client.Views;
using SpringBoxXIII.Client.ViewModels;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}
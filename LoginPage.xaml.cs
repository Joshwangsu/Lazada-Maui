namespace Lazada;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnEmailLoginTapped(object sender, EventArgs e)
    {
        // Navigate to the actual Firebase email/password authentication page
        await Navigation.PushAsync(new EmailAuthPage());
    }

    private async void OnCloseTapped(object sender, EventArgs e)
    {
        // Close the login page
        await Navigation.PopAsync();
    }
}

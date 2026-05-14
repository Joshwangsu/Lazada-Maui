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
}

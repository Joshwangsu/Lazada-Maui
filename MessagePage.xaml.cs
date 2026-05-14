namespace Lazada;

public partial class MessagePage : ContentPage
{
	public MessagePage()
	{
		InitializeComponent();
	}

	private async void OnHomeTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//MainPage");
	}

	private async void OnLazMallTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LazMallPage());
	}

	private async void OnAccountTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AccountPage());
	}

	private async void OnCartTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CartPage());
	}
}

namespace Lazada;

public partial class AccountPage : ContentPage
{
    public AccountPage()
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

    private async void OnMessageTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MessagePage());
    }

    private async void OnCartTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CartPage());
    }
}

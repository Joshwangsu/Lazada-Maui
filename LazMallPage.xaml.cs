namespace Lazada;

public partial class LazMallPage : ContentPage
{
    public LazMallPage()
    {
        InitializeComponent();
    }

    private async void OnHomeTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnAccountTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountPage());
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

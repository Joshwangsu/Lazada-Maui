namespace Lazada;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
        NavigateToMain();
    }

    private async void NavigateToMain()
    {
        // Wait for 3 seconds to show the splash screen
        await Task.Delay(3000);
        
        // Navigate to the Login Page wrapped in a NavigationPage
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
}

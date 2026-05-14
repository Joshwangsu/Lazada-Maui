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

    private async void OnGoogleLoginTapped(object sender, EventArgs e)
    {
        try
        {
            // 1. Initiate Google Sign-In via MAUI WebAuthenticator
            var authUrl = new Uri("https://lazada-mobile-7e132.firebaseapp.com/__/auth/handler");
            var callbackUrl = new Uri("lazada://"); // Custom URI scheme you must register in Android/iOS project

            var result = await WebAuthenticator.Default.AuthenticateAsync(authUrl, callbackUrl);

            string idToken = result.Properties["id_token"];

            // 2. Authenticate with Firebase using the Google ID Token
            // Build a GoogleCredential and sign in with it
            var credential = Firebase.Auth.Providers.GoogleProvider.GetCredential(idToken);
            var firebaseClient = new Firebase.Auth.FirebaseAuthClient(new Firebase.Auth.FirebaseAuthConfig
            {
                ApiKey = "AIzaSyB5jpRKgD6gfVQeFOvxoQijmg_YSFrnSak",
                AuthDomain = "lazada-mobile-7e132.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new Firebase.Auth.Providers.GoogleProvider()
                }
            });

            var userCredential = await firebaseClient.SignInWithCredentialAsync(credential);

            // 3. Success - Navigate to main page
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch (TaskCanceledException)
        {
            // User canceled the login flow
            await DisplayAlert("Cancelled", "Google sign in was cancelled.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Google Sign-In failed: {ex.Message}", "OK");
        }
    }
}

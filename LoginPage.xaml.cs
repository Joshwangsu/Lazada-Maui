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
            // Note: To make this work, you must set up Firebase Google Auth in the console.
            // You will need a Web Client ID from your Google Cloud Console.
            // Below is the standard MAUI WebAuthenticator implementation for OAuth.
            
            // Replace with your actual Firebase Auth Domain
            string authDomain = "YOUR_PROJECT_ID.firebaseapp.com"; 
            
            // The callback URL must be registered in your MAUI App (e.g., lazada://)
            // and added to the Firebase Console -> Authentication -> Settings -> Authorized Domains.
            var authUrl = new Uri($"https://{authDomain}/__/auth/handler");
            var callbackUrl = new Uri("lazada://");

            // Open the system browser for Google login
            var authResult = await WebAuthenticator.Default.AuthenticateAsync(authUrl, callbackUrl);

            // Extract the access token / id token from the result
            string idToken = authResult?.IdToken;

            if (!string.IsNullOrEmpty(idToken))
            {
                // Here you would typically pass the idToken to your FirebaseAuthClient
                // var credential = await _firebaseAuthClient.SignInWithGoogleIdTokenAsync(idToken);
                await DisplayAlert("Success", "Google Login Successful!", "OK");
                await Shell.Current.GoToAsync("//MainPage");
            }
        }
        catch (TaskCanceledException)
        {
            // User canceled the login flow
            await DisplayAlert("Canceled", "Google login was canceled.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to login with Google: {ex.Message}", "OK");
        }
    }
}

using Firebase.Auth;
using Firebase.Auth.Providers;
using System.Diagnostics;

namespace Lazada;

public partial class EmailAuthPage : ContentPage
{
    private const string FirebaseApiKey = "AIzaSyB5jpRKgD6gfVQeFOvxoQijmg_YSFrnSak";
    private const string FirebaseAuthDomain = "lazada-mobile-7e132.firebaseapp.com";
    
    private FirebaseAuthClient _firebaseAuthClient;

    public EmailAuthPage()
    {
        InitializeComponent();
        SetupFirebase();
    }

    private void SetupFirebase()
    {
        try
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = FirebaseApiKey,
                AuthDomain = FirebaseAuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            };
            
            _firebaseAuthClient = new FirebaseAuthClient(config);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Firebase setup error: {ex.Message}");
        }
    }

    private async void OnSignInClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            ShowError("Please enter both email and password.");
            return;
        }

        if (FirebaseApiKey == "YOUR_FIREBASE_API_KEY")
        {
            ShowError("Please configure your Firebase API Key in EmailAuthPage.xaml.cs");
            return;
        }

        try
        {
            ErrorLabel.IsVisible = false;
            Button signInButton = (Button)sender;
            signInButton.Text = "SIGNING IN...";
            signInButton.IsEnabled = false;

            // Attempt Firebase login
            var userCredential = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(email, password);
            
            // On success, navigate to main app
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception ex)
        {
            ShowError($"Login failed: {ex.Message}");
        }
        finally
        {
            Button signInButton = (Button)sender;
            signInButton.Text = "SIGN IN";
            signInButton.IsEnabled = true;
        }
    }

    private async void OnSignUpTapped(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            ShowError("Please enter email and password to sign up.");
            return;
        }

        if (FirebaseApiKey == "YOUR_FIREBASE_API_KEY")
        {
            ShowError("Please configure your Firebase API Key in EmailAuthPage.xaml.cs");
            return;
        }

        try
        {
            ErrorLabel.IsVisible = false;
            
            // Attempt Firebase registration
            var userCredential = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(email, password);
            
            await DisplayAlert("Success", "Account created! You are now logged in.", "OK");
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception ex)
        {
            ShowError($"Registration failed: {ex.Message}");
        }
    }

    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }
}

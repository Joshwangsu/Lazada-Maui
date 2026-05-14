namespace Lazada;

public partial class GoogleAuthPage : ContentPage
{
    private readonly string _callbackUrl;
    public TaskCompletionSource<string?> AuthResult { get; } = new();

    public GoogleAuthPage(string authUrl, string callbackUrl)
    {
        InitializeComponent();
        _callbackUrl = callbackUrl;
        authWebView.Source = authUrl;
    }

    private async void OnWebViewNavigating(object sender, WebNavigatingEventArgs e)
    {
        loadingIndicator.IsVisible = true;
        
        // Check if the URL is our callback URL
        if (e.Url.StartsWith(_callbackUrl))
        {
            e.Cancel = true; 
            
            var uri = new Uri(e.Url);
            var fragment = uri.Fragment;
            if (string.IsNullOrEmpty(fragment)) fragment = uri.Query;

            if (!string.IsNullOrEmpty(fragment))
            {
                var content = fragment.TrimStart('#', '?');
                var parts = content.Split('&');
                foreach (var part in parts)
                {
                    var kv = part.Split('=');
                    if (kv.Length == 2 && kv[0] == "id_token")
                    {
                        AuthResult.SetResult(Uri.UnescapeDataString(kv[1]));
                        await Navigation.PopAsync();
                        return;
                    }
                }
            }
            
            AuthResult.SetResult(null);
            await Navigation.PopAsync();
        }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        loadingIndicator.IsVisible = false;
    }
}

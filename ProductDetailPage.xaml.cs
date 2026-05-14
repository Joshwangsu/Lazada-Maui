namespace Lazada;

public partial class ProductDetailPage : ContentPage
{
    public ProductDetailPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

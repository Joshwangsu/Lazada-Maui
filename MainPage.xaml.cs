namespace Lazada
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.MainViewModel();
        }

        private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Models.Product selectedProduct)
            {
                // Deselect the item
                ((CollectionView)sender).SelectedItem = null;

                // Navigate to detail page
                await Navigation.PushAsync(new ProductDetailPage());
            }
        }

        private async void OnAccountTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountPage());
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
}

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
    }
}

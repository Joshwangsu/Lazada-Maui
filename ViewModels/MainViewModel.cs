using System.Collections.ObjectModel;
using Lazada.Models;

namespace Lazada.ViewModels;

public class MainViewModel
{
    public ObservableCollection<Product> FlashSaleProducts { get; set; }
    public ObservableCollection<Product> JustForYouProducts { get; set; }

    public MainViewModel()
    {
        FlashSaleProducts = new ObservableCollection<Product>
        {
            new Product { Name = "Wireless Earbuds Pro", Price = 999, OriginalPrice = 1999, ImageUrl = "product_earbuds.png" },
            new Product { Name = "Mechanical Gaming Keyboard", Price = 1499, OriginalPrice = 2999, ImageUrl = "product_keyboard.png" },
            new Product { Name = "Smart Watch Series 7", Price = 2499, OriginalPrice = 4999, ImageUrl = "product_smartwatch.png" },
            new Product { Name = "Premium Coffee Maker", Price = 899, OriginalPrice = 1299, ImageUrl = "product_coffee_maker.png" }
        };

        JustForYouProducts = new ObservableCollection<Product>
        {
            new Product { Name = "GUMAHUS | Casual Sneakers Loafers Men's Comfort", Price = 554.59, Rating = 5, SoldCount = "57 sold", DiscountLabel = "100% Authentic", ImageUrl = "product_sneakers.png" },
            new Product { Name = "SMART | Pro Smartwatch with Heart Rate Monitor", Price = 1250.00, Rating = 4.9, SoldCount = "87.5k sold", DiscountLabel = "Lowest Price Guarantee", ImageUrl = "product_smartwatch.png" },
            new Product { Name = "ARCTIC | Waterproof Laptop Backpack Navy Blue", Price = 749.00, Rating = 4.8, SoldCount = "1.2k sold", DiscountLabel = "Official Store", ImageUrl = "product_backpack.png" },
            new Product { Name = "SOUNDCORE | Wireless Bluetooth Earbuds Black", Price = 1350.00, Rating = 5, SoldCount = "10k+ sold", DiscountLabel = "Official Store", ImageUrl = "product_earbuds.png" }
        };
    }
}

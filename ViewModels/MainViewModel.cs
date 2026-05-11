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
            new Product { Name = "Item 1", Price = 99, OriginalPrice = 199 },
            new Product { Name = "Item 2", Price = 149, OriginalPrice = 299 },
            new Product { Name = "Item 3", Price = 49, OriginalPrice = 99 },
            new Product { Name = "Item 4", Price = 899, OriginalPrice = 1299 }
        };

        JustForYouProducts = new ObservableCollection<Product>
        {
            new Product { Name = "gumahus | Casual Comfort Slip-on Loafers Men's...", Price = 554.59, Rating = 5, SoldCount = "57 sold", DiscountLabel = "100% Authentic", ImageColor = "#4A148C" },
            new Product { Name = "【Fadikou】 900ml Large Capacity Tumbler With S...", Price = 38.00, Rating = 4.9, SoldCount = "87.5k sold", DiscountLabel = "Lowest Price Guarantee", ImageColor = "#D81B60" },
            new Product { Name = "H.CHENG HOME | Modern Blackout Curtains for...", Price = 249.00, Rating = 4.8, SoldCount = "1.2k sold", DiscountLabel = "Official Store", ImageColor = "#00796B" },
            new Product { Name = "Unilever Official Store | Clear Shampoo 450ml", Price = 350.00, Rating = 5, SoldCount = "10k+ sold", DiscountLabel = "Official Store", ImageColor = "#E65100" }
        };
    }
}

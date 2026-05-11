namespace Lazada.Models;

public class Product
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public double Price { get; set; }
    public double OriginalPrice { get; set; }
    public double Rating { get; set; }
    public string SoldCount { get; set; }
    public string DiscountLabel { get; set; }
    public string ImageColor { get; set; }
    public string FirstLetter => string.IsNullOrEmpty(Name) ? "" : Name.Substring(0, 1).ToUpper();
}

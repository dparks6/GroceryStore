public class Cart
{
    public int cartId { get; set; }
    public string userId { get; set;
    public SortedDictionary<Product, int> itemList { get; set;}
    public double totalPrice { get; set; }
}
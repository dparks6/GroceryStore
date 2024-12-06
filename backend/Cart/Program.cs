using System;

public class Program
{
    public void Main(string[] args)
    {
        string connectionString = "";

        int id = 0;

        ICartRepository cartRepository = new CartRepository(connectionString);

        ICartAccessor cartAccessor = new CartAccessor(cartRepository);

        Cart cart = cartAccessor.getUserCart(id);

        if (cart != null)
        {
            Console.WriteLine($"CartID: {cart.cartId}, UserID: {cart.userId}, itemList: {cart.itemList}, Price: {cart.totalPrice}");
        }
        else
        {
            Console.WriteLine("Cart not found.");
        }
    }
}
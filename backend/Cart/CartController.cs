using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private ICartRepository _cartRepository;

    public CartAccessor(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    
    public Cart getUserCart(string userId)
    {
        User user = await _cartRepository[HttpGet("{userId}")].GetUserById(userId);
        if (user == null)
        {
            Console.WriteLine("Unable to Create User.");
        }
        return user;
    }

    [HttpGet("{cartId}/{product}/{amount}")]
    async void addToCart(int cartId, Product product, int amount)
    {
        bool success = await _cartRepository.addToCart(cartId, product, amount);
        if (!success)
        {
            Console.WriteLine("Unable to add to cart");
        }
        return;
    }

    [HttpGet("{cartId}/{product}")]
    void removeFromCart(int cartId, Product product)
    {
        bool success = await _cartRepository.removeFromCart(cartId, product);
        if (!success)
        {
            Console.WriteLine("Unable to remove from cart");
        }
        return;
    }

    [HttpGet("{cartId}/{product}/{amount}")]
    void updateAmount(int cartId, Product product, int amount)
    {
        bool success = await _cartRepository.updateAmount(cartId, product, amount);
        if (!success)
        {
            Console.WriteLine("Unable to update amount in cart");
        }
        return;
    }

    [HttpGet("{cart}")]
    void initiateCart(Cart cart)
    {
        bool success = await _cartRepository.initiateCart(cart);
        if (!success)
        {
            Console.WriteLine("Unable to initiate cart");
        }
        return;
    }

    [HttpGet("{cartId}")]
    void clearCart(int cartId)
    {
        bool success = await _cartRepository.clearCart(cartId);
        if (!success)
        {
            Console.WriteLine("Unable to clear cart");
        }
        return;
    }
}
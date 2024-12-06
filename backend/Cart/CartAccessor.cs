public class CartAccessor : ICartAccessor
{
    private ICartRepository _cartRepository;

    public CartAccessor(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Cart getUserCart(string userId)
    {
        return _cartRepository.getUserCart(userId);
    }

    void addToCart(int cartId, Product product, int amount)
    {
        _cartRepository.addToCart(cartId, product, amount);
        return;
    }

    void removeFromCart(int cartId, Product product)
    {
        _cartRepository.removeFromCart(cartId, product);
        return;
    }

    void updateAmount(int cartId, Product product, int amount)
    {
        _cartRepository.updateAmount(cartId, product, amount);
        return;
    }

    void initiateCart(Cart cart)
    {
        _cartRepository.initiateCart(cart);
        return;
    }

    void clearCart(int cartId)
    {
        _cartRepository.clearCart(cartId);
        return;
    }
}
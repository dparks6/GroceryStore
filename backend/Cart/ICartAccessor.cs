public interface ICartAccessor
{
    public Cart getUserCart(string userId);
    void addToCart(int cartId, Product product, int amount);
    void removeFromCart(int cartId, Product product);
    void updateAmount(int cartId, Product product, int amount);
    void initiateCart(Cart cart);
    void clearCart(int cartId);
}
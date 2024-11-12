public interface IProductRepository
{
    Product GetProductById(int productId);
    List<Product> GetAllProducts();
    void UpdateProductStock(int productId, int stock);
    void ApplyDiscount(int productId, double discount);
    
}

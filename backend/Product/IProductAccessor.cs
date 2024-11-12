public interface IProductAccessor 
{
  public Product GetProductById(int productId);
  public List<Product> GetAllProducts();
  public void UpdateProductStock(int productId, int stock);
  public void ApplyDiscountToProduct(int productId, double discount);
}
public class ProductAccessor : IProductAccessor
{
  private IProductRepository _productRepository;

  public ProductAccessor(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public Product GetProductById(int productId)
  {
    return _productRepository.GetProductById(productId);
  }

  public List<Product> GetAllProducts()
  {
    return _productRepository.GetAllProducts();
  }

  public void UpdateProductStock(int productId, int stock)
  {
      // TODO
  }

  public void ApplyDiscountToProduct(int productId, double discount)
  {
      // TODO
  }
}

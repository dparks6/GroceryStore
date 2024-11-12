public class ProductService 
{
  private IProductRepository _productRepository;

  public ProductService(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }


  public ProductService ViewProductDetails(int productId)
  {
    return _productRepository.GetProductById(productId);
  }

  public void ApplyDiscountToProduct(int productId, double discount)
  {
    _productRepository.ApplyDiscount(productId, discount);
  }

  public bool checkProductAvailability(int productId) 
  {
    return _productRepository.inStock(productId);
  }

  public void UpdateProductStock(int productId, int stock) 
  {
    _productRepository.UpdateStock(productId, stock);
  }




}
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  private ProductService _productService;

  public ProductController(ProductService productService)
  {
    _productService = productService;
  }

  [HttpGet("{productId}")]
  public ActionResult<Product> ViewProductDetails(int productId) 
  {
    var product = _productService.ViewProductDetails(productId);
    if(product == null) {
      return NotFound();
    }
    return Ok(product);
  }

  // TODO 
  // ApplyDiscount
  // UpdateStock
  // CheckAvailability

}
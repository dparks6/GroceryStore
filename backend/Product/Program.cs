using System;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "";

        IProductRepository productRepository = new ProductRepository(connectionString);

        IProductAccessor productAccessor = new ProductAccessor(productRepository);

        Product product = productAccessor.GetProductById(1);

        if (product != null)
        {
          Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
        }
        else
        {
          Console.WriteLine("Product not found.");
        }
    }
}

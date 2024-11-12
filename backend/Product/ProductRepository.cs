using System.Data.SqlClient;

public class ProductRepository : IProductRepository
{
  private string _connectionString;

  public ProductRepository(string connectionString) 
  {
    _connectionString = connectionString;
  }

  public ProductRepository GetProductById(int productId) 
  {
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
      connection.Open();

      string query = "SELECT * FROM Products WHERE ProductID = @ProductId";
      using(SqlCommand cmd = new SqlCommand(query, connection))
      {
        cmd.Parameters.AddWithValue("@ProductID", productId);
        using(SqlDataReader reader = cmd.ExecuteReader())
        {
          if(reader.read()) 
          {
            return new Product
            {
              productID = (int)reader["ProductID"],
              name = reader["Name"].ToString(),
              description = reader["Description"].ToString(),
              price = (double)reader["Price"],
              manufacturer = reader["Manufacturer"].ToString(),
              dimensions = reader["Dimensions"].ToString(),
              weight = (double)reader["Weight"],
              rating = (double)reader["Rating"],
              SKU = reader["SKU"].ToString(),
              categoryID = (int)reader["CategoryID"],
              stock = (int)reader["Stock"],
              discount = (double)reader["Discount"],
              discountStartDate = (DateTime)reader["DiscountStartDate"],
              discountEndDate = (DateTime)reader["DiscountEndDate"]
            }
          }
        }
      }
    }
    return null;
  }

  public List<Product> GetAllProducts() 
  {
    // TODO
  }
  
  public void UpdateStock(int productId, int stock)
  {
    // TODO
  }

  public void ApplyDiscount(int productId, double discount)
  {
    // TODO
  }
  
  public boolean inStock(int productId) 
  {
    // TODO 
  }

  public void EditRating(int productId, double rating) 
  {
    // TODO
  }
}

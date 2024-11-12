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
              ProductID = (int)reader["ProductID"],
              Name = reader["Name"].ToString(),
              Description = reader["Description"].ToString(),
              Price = (double)reader["Price"],
              Manufacturer = reader["Manufacturer"].ToString(),
              Dimensions = reader["Dimensions"].ToString(),
              Weight = (double)reader["Weight"],
              Rating = (double)reader["Rating"],
              SKU = reader["SKU"].ToString(),
              CategoryID = (int)reader["CategoryID"],
              Stock = (int)reader["Stock"],
              Discount = (double)reader["Discount"],
              DiscountStartDate = (DateTime)reader["DiscountStartDate"],
              DiscountEndDate = (DateTime)reader["DiscountEndDate"]
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

using System.Data.SqlClient;

public class CartRepository : ICartRepository
{
    private readonly string _connectionString;

    public CartRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Cart getUserCart(string userId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM Cart WHERE UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.read())
                    {
                        return new Cart
                        {
                            cartId = (int)reader["CartID"],
                            userId = (int)reader["UserID"],
                            itemList = reader["itemList"],
                            totalPrice = (double)reader["Price"]
                        }
                    }
                }
            }
        }
    }

    void addToCart(int cartId, Product product, int amount)
    {
        SortedDictionary<Product, int> tempList;
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = "SELECT itemList FROM Cart WHERE CartID = @cartId";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@cartID", userId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.read())
                    {
                        tempList = reader["itemList"];
                    }
                }
            }
            connection.Close();

            tempList.Add(product, amount);

            connection.Open();
            query = @"UPDATE Users SET itemList = @itemList
                    WHERE CartId = @cartId";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Parameters.AddWithValue("@cartID", cartId);
                connection.Parameters.AddWithValue("@itemList", tempList);
                connection.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }

    void removeFromCart(int cartId, Product product)
    {
        SortedDictionary<Product, int> tempList;
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = "SELECT itemList FROM Cart WHERE CartID = @cartId";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@cartID", userId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.read())
                    {
                        tempList = reader["itemList"];
                    }
                }
            }
            connection.Close();

            tempList.Remove(product);

            connection.Open();
            query = @"UPDATE Users SET itemList = @itemList
                    WHERE CartId = @cartId";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Parameters.AddWithValue("@cartID", cartId);
                connection.Parameters.AddWithValue("@itemList", tempList);
                connection.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }

    void updateAmount(int cartId, Product product, int amount)
    {
        SortedDictionary<Product, int> tempList;
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = "SELECT itemList FROM Cart WHERE CartID = @cartId";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@cartID", userId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.read())
                    {
                        tempList = reader["itemList"];
                    }
                }
            }
            connection.Close();

            tempList[product] = amount;

            connection.Open();
            query = @"UPDATE Users SET itemList = @itemList
                    WHERE CartId = @cartId";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Parameters.AddWithValue("@cartID", cartId);
                connection.Parameters.AddWithValue("@itemList", tempList);
                connection.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }

    void initiateCart(Cart cart)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = @"INSERT INTO Cart (UserID, itemList, Price) 
                          VALUES(@UserID, @itemList, @Price);
                          SELECT CAST(SCOPE_IDENTITY() as int)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Parameters.AddWithValue("@UserID", cart.userId);
                connection.Parameters.AddWithValue("@itemList", cart.itemList);
                connection.Parameters.AddWithValue("@Price", cart.totalPrice);
                connection.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }

    void clearCart(int cartId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var query = "DELETE FROM Cart WHERE CartID = @Id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Parameters.AddWithValue("@ID", cartId);
                connection.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }
}
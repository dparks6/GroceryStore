using System.Data.SqlClient;
using CombinedAPI.Models;
using CombinedAPI.Interfaces;

namespace CombinedAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Users WHERE UserID = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                userID = (int)reader["UserID"],
                                username = reader["Username"].ToString(),
                                firstName = reader["FirstName"].ToString(),
                                lastName = reader["LastName"].ToString(),
                                address = reader["Address"].ToString(),
                                email = reader["Email"].ToString(),
                                phoneNumber = reader["PhoneNumber"].ToString(),
                                password = reader["Password"].ToString(),
                                creditcardNumber = reader["CreditCardNumber"].ToString(),
                                creditcardExpDate = reader["CreditCardExpDate"].ToString(),
                                cvv = (int)reader["CVV"],
                                shippingLocation = reader["ShippingLocation"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool CreateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"INSERT INTO Users (Username, FirstName, LastName, Address, Email, PhoneNumber, Password, CreditCardNumber, CreditCardExpDate, CVV, ShippingLocation) 
                            VALUES (@Username, @FirstName, @LastName, @Address, @Email, @PhoneNumber, @Password, @CreditCardNumber, @CreditCardExpDate, @CVV, @ShippingLocation);";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    cmd.Parameters.AddWithValue("@FirstName", user.firstName);
                    cmd.Parameters.AddWithValue("@LastName", user.lastName);
                    cmd.Parameters.AddWithValue("@Address", user.address);
                    cmd.Parameters.AddWithValue("@Email", user.email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.phoneNumber);
                    cmd.Parameters.AddWithValue("@Password", user.password);
                    cmd.Parameters.AddWithValue("@CreditCardNumber", user.creditcardNumber);
                    cmd.Parameters.AddWithValue("@CreditCardExpDate", user.creditcardExpDate);
                    cmd.Parameters.AddWithValue("@CVV", user.cvv);
                    cmd.Parameters.AddWithValue("@ShippingLocation", user.shippingLocation);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateUser(int id, User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"UPDATE Users 
                              SET Username = @Username, FirstName = @FirstName, LastName = @LastName, Address = @Address, Email = @Email, PhoneNumber = @PhoneNumber, Password = @Password, CreditCardNumber = @CreditCardNumber, CreditCardExpDate = @CreditCardExpDate, CVV = @CVV, ShippingLocation = @ShippingLocation 
                              WHERE UserID = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    cmd.Parameters.AddWithValue("@FirstName", user.firstName);
                    cmd.Parameters.AddWithValue("@LastName", user.lastName);
                    cmd.Parameters.AddWithValue("@Address", user.address);
                    cmd.Parameters.AddWithValue("@Email", user.email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.phoneNumber);
                    cmd.Parameters.AddWithValue("@Password", user.password);
                    cmd.Parameters.AddWithValue("@CreditCardNumber", user.creditcardNumber);
                    cmd.Parameters.AddWithValue("@CreditCardExpDate", user.creditcardExpDate);
                    cmd.Parameters.AddWithValue("@CVV", user.cvv);
                    cmd.Parameters.AddWithValue("@ShippingLocation", user.shippingLocation);
                    cmd.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Users WHERE UserID = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}

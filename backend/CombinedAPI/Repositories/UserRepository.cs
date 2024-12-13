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
                                id = (int)reader["UserID"],
                                username = reader["Username"].ToString(),
                                password = reader["PasswordHash"].ToString(),
                                email = reader["Email"].ToString()
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
                var query = @"INSERT INTO Users (Username, PasswordHash, Email) 
                            VALUES (@Username, @PasswordHash, @Email);
                            SELECT CAST(SCOPE_IDENTITY() as int)";  

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.password);
                    cmd.Parameters.AddWithValue("@Email", user.email);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }

        public bool UpdateUser(int id, User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, Email = @Email 
                            WHERE UserID = @Id";  
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.password);
                    cmd.Parameters.AddWithValue("@Email", user.email);
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

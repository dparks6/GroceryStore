public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Users WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
        }
    }

    public async Task<int> CreateUserAsync(User user)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = @"INSERT INTO Users (Username, PasswordHash, Address, CreditCard, PhoneNumber, Email) 
                          VALUES (@Username, @PasswordHash, @Address, @CreditCard, @PhoneNumber, @Email);
                          SELECT CAST(SCOPE_IDENTITY() as int)";
            return await connection.ExecuteScalarAsync<int>(query, user);
        }
    }

    public async Task<bool> UpdateUserAsync(int id, User user)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = @"UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, 
                          Address = @Address, CreditCard = @CreditCard, PhoneNumber = @PhoneNumber, Email = @Email 
                          WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { user.Username, user.PasswordHash, user.Address, user.CreditCard, user.PhoneNumber, user.Email, Id = id });
            return rowsAffected > 0;
        }
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var query = "DELETE FROM Users WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
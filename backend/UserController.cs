[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateUser(User user)
    {
        user.PasswordHash = HashPassword(user.PasswordHash);
        int userId = await _userRepository.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUser), new { id = userId }, userId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        user.PasswordHash = HashPassword(user.PasswordHash);
        bool success = await _userRepository.UpdateUserAsync(id, user);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        bool success = await _userRepository.DeleteUserAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
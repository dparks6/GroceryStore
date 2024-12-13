using Microsoft.AspNetCore.Mvc;
using System;
using CombinedAPI.Models;
using CombinedAPI.Repositories;

namespace CombinedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/user/id/{id}
        [HttpGet("id/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                Console.WriteLine($"Getting user by ID: {id}");
                var user = _userRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // POST: api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                Console.WriteLine("Creating new user");
                var success = _userRepository.CreateUser(user);
                if (!success)
                {
                    return BadRequest("Failed to create user.");
                }
                return Ok("User created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/user/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                Console.WriteLine($"Updating user with ID: {id}");
                var success = _userRepository.UpdateUser(id, user);
                if (!success)
                {
                    return NotFound("User not found or failed to update.");
                }
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                Console.WriteLine($"Deleting user with ID: {id}");
                var success = _userRepository.DeleteUser(id);
                if (!success)
                {
                    return NotFound("User not found or failed to delete.");
                }
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

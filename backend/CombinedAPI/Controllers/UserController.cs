using Microsoft.AspNetCore.Mvc;
using System;
using CombinedAPI.Models;
using CombinedAPI.Repositories;
using CombinedAPI.Interfaces;

namespace CombinedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccessor _userAccessor;

        public UserController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }
        
        // GET: api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                Console.WriteLine("Fetching all users");
                var user = _userAccessor.GetAllUsers();
                if (user == null || !user.Any())
                {
                    return NotFound("User not Found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // GET: api/user/id/{id}
        [HttpGet("id/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                Console.WriteLine($"Getting user by ID: {id}");
                var user = _userAccessor.GetUserById(id);
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

        // POST: api/user/create
        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                Console.WriteLine("Creating new user");
                var success = _userAccessor.CreateUser(user);
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
                var success = _userAccessor.UpdateUser(id, user);
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

        // DELETE: api/user/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                Console.WriteLine($"Deleting user with ID: {id}");
                var success = _userAccessor.DeleteUser(id);
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

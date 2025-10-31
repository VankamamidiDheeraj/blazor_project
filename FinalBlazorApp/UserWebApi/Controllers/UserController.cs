using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserLibrary.Models;
using UserLibrary.Repos;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        IUserRepository userRepo;
        public UserController(IUserRepository repo)
        {
            userRepo = repo;
        }
        [HttpPost("{userId}/{password}")]
        public async Task<IActionResult> Register(string userId, string password)
        {
            try
            {
                await userRepo.RegisterAsync(userId, password);
                return Ok();
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{userId}/{password}")]
        public async Task<IActionResult> Login(string userId, string password)
        {
            try
            {
                UserRole userRole = await userRepo.LoginAsync(userId, password);
                return Ok(userRole);
            }
            catch (UserException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_DemoWebAPIWithAuth.Models;
using Web_DemoWebAPIWithAuth.Services;

namespace Web_DemoWebAPIWithAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthApiController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // For demonstration purposes, we are using hardcoded credentials.
            // In a real application, you should validate the credentials against a database.
            if (request.UserName == "admin" && request.Password == "password") // Replace with your actual authentication logic
            {
                var token = _tokenService.GenerateToken(request.UserName);
                return Ok(new { token });
            }
            return Unauthorized("Invalid Credentials! Access denied...");
        }
    }
}

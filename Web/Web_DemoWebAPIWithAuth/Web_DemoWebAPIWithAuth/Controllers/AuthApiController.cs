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
            if (request.UserName == "saket" && request.Password == "password") // Replace with your actual authentication logic
            {
                var role = request.UserName == "admin" ? "Admin" : "User"; // Assign role based on username

                var token = _tokenService.GenerateToken(request.UserName, role);
                var refreshToken = _tokenService.GenerateRefreshToken(request.UserName);
                RefreshTokenStore.RefreshTokens.Add(refreshToken); // Store the refresh token for later validation

                //return Ok(new { token });
                return Ok(new AuthResponse() { AccessToken = token, RefreshToken = refreshToken.Token });
            }
            return Unauthorized("Invalid Credentials! Access denied...");
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] string refreshToken)
        {
            var storedToken = RefreshTokenStore.RefreshTokens.FirstOrDefault(rt => rt.Token == refreshToken && !rt.IsRevoked);
            if (storedToken == null || storedToken.IsRevoked || storedToken.ExpiresAt < DateTime.Now)
            {
                return Unauthorized("Invalid or expired refresh token.");
            }

            // Rotate refresh token
            // Revoke the old refresh token
            storedToken.IsRevoked = true;

            var newRefreshToken = _tokenService.GenerateRefreshToken(storedToken.UserName);
            // Store the new refresh token
            RefreshTokenStore.RefreshTokens.Add(newRefreshToken);

            // Generate a new access token
            var role = storedToken.UserName == "admin" ? "Admin" : "User"; // Assign role based on username
            var newToken = _tokenService.GenerateToken(storedToken.UserName, role);

            return Ok(new AuthResponse() { AccessToken = newToken, RefreshToken = newRefreshToken.Token });
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            var storedToken = RefreshTokenStore.RefreshTokens.FirstOrDefault(rt => rt.Token == request.RefreshToken && !rt.IsRevoked);
            if (storedToken == null)
            {
                return BadRequest("Invalid refresh token.");
            }
            storedToken.IsRevoked = true; // Revoke the refresh token
            storedToken.RevokedAt = DateTime.Now; // Optionally set the revoked time
            return Ok("Logged out successfully.");
        }

        [HttpPost("logoutalldevices")]
        public IActionResult LogoutAllDevices([FromBody] string userName)
        {
            var storedTokens = RefreshTokenStore.RefreshTokens.Where(rt => rt.UserName == userName).ToList();
            foreach (var token in storedTokens)
            {
                token.IsRevoked = true;
                token.RevokedAt = DateTime.Now;
            }
            return Ok("Logged out successfully from all devices.");
        }
    }
}

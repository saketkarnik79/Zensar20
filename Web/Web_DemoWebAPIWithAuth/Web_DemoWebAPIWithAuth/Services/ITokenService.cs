using Web_DemoWebAPIWithAuth.Models;

namespace Web_DemoWebAPIWithAuth.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userName, string role);

        RefreshToken GenerateRefreshToken(string userName);
    }
}

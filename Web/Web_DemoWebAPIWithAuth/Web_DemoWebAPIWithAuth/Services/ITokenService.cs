namespace Web_DemoWebAPIWithAuth.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userName);
    }
}

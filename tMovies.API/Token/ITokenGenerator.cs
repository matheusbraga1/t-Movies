using tMovies.API.Models;

namespace tMovies.API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}

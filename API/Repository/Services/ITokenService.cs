using Repository.Entities.Identity;

namespace Repository.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}

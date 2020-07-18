using Repository.Entities.Identity;

namespace Repository.Repositories
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}

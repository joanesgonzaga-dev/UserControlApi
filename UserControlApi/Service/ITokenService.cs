using Microsoft.AspNetCore.Identity;
using UserControlApi.Model;

namespace UserControlApi.Service
{
    public interface ITokenService
    {
        public Token CriarToken(IdentityUser<Guid> user);
    }
}

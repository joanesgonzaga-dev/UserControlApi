using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserControlApi.Model;

namespace UserControlApi.Service
{
    public class TokenService : ITokenService
    {
        public Token CriarToken(IdentityUser<Guid> user)
        {
            Claim[] direitosDeUsuario = new Claim[] {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("c49ci49ic49uc84uc8hhhyhyc4c49i9i9u8"));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                claims : direitosDeUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }
    }
}

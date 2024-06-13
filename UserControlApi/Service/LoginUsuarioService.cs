using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserControlApi.Model;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public class LoginUsuarioService : ILoginUsuarioService
    {
        private SignInManager<IdentityUser<Guid>> _signInManager;
        private TokenService _tokenService;
        public LoginUsuarioService(SignInManager<IdentityUser<Guid>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public Result Login(UsuarioLoginDTO usuarioLogin)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(
                usuarioLogin.UserName, usuarioLogin.Password, false, false);

            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users.FirstOrDefault(
                    usuario => usuario.NormalizedUserName == usuarioLogin.UserName.ToUpper());
                Token token = _tokenService.CriarToken(identityUser);

                return Result.Ok().WithSuccess(token.Value);
            } 
            return Result.Fail("Falha ao executar o login");
        }
    }
}

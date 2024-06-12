using FluentResults;
using Microsoft.AspNetCore.Identity;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public class LoginUsuarioService : ILoginUsuarioService
    {
        private SignInManager<IdentityUser<Guid>> _signInManager;
        public LoginUsuarioService(SignInManager<IdentityUser<Guid>> signInManager)
        {
                _signInManager = signInManager;
        }
        public Result Login(UsuarioLoginDTO usuarioLogin)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(
                usuarioLogin.UserName, usuarioLogin.Password, false, false);

            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao executar o login");
        }
    }
}

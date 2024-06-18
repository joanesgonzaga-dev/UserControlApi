using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserControlApi.Model;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public class LoginService : ILoginService
    {
        private SignInManager<IdentityUser<Guid>> _signInManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<Guid>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public Result Logar(UsuarioLoginDTO? usuarioLogin)
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
            return Result.Fail("Não foi possível executar o login");
        }

        public Result SolicitarReset(UsuarioSolicitaResetarSenhaDTO emailUsuarioDTO)
        {
            IdentityUser<Guid> identityUser = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == emailUsuarioDTO.Email.ToUpper());

            //Gerar Token válido para permitir alteração de senha de usuário
            if (identityUser != null)
            {
                string tokenDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

                return Result.Ok().WithSuccess(tokenDeRecuperacao);
            }

            return Result.Fail("Falha ao solicitar alteração de senha");
        }
    }
}

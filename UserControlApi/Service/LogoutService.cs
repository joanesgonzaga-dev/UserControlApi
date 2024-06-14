using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UserControlApi.Service
{
    public class LogoutService : ILogoutService
    {
        private SignInManager<IdentityUser<Guid>> _signinManager;

        public LogoutService(SignInManager<IdentityUser<Guid>> signinManager)
        {
            _signinManager = signinManager;
        }
        public Result Logout()
        {
            var resultadoIdentity = _signinManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();

            return Result.Fail("Erro ao tentar executar Logout");
        }
    }
}

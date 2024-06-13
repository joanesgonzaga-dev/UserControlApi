using FluentResults;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public interface ILoginService
    {
        public Result ToLogin(UsuarioLoginDTO usuarioLogin);
    }
}

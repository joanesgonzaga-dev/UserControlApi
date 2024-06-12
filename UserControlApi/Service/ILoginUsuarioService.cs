using FluentResults;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public interface ILoginUsuarioService
    {
        public Result Login(UsuarioLoginDTO usuarioLogin);
    }
}

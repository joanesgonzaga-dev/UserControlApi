using FluentResults;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public interface ILoginService
    {
        public Result Logar(UsuarioLoginDTO usuarioLogin);
        public Result SolicitarReset(UsuarioSolicitaResetarSenhaDTO senhaDTO);
    }
}

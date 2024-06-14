using FluentResults;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public interface IRegistrarUsuarioService
    {
        public Result Registrar(UsuarioCadastroDTO cadastroDTO);

        public Result Ativar(UsuarioAtivacaoDTO usuario);
    }
}

using FluentResults;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public interface ICadastraUsuarioService
    {
        public Result CadastraUsuario(UsuarioCadastroDTO cadastroDTO);
    }
}

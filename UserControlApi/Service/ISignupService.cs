using FluentResults;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public interface ISignupService
    {
        public Result ToRegister(UsuarioCadastroDTO cadastroDTO);
    }
}

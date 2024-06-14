using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserControlApi.Model.DTO;
using UserControlApi.Service;

namespace UserControlApi.Controllers
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class RegistrarController : ControllerBase
    {
        private IRegistrarUsuarioService _registrarUsuarioService;
        public RegistrarController(IRegistrarUsuarioService registrarUsuarioService)
        {
                _registrarUsuarioService = registrarUsuarioService;
        }

        [HttpPost]
        public IActionResult RegistrarConta(UsuarioCadastroDTO cadastroDTO)
        {
            Result resultado = _registrarUsuarioService.Registrar(cadastroDTO);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }

        [HttpPost("ativar")]
        public IActionResult AtivarConta(UsuarioAtivacaoDTO usuario)
        {
            Result result = _registrarUsuarioService.Ativar(usuario);
            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Successes);
        }
    }
}

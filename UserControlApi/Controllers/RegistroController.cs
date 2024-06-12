using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserControlApi.Model.DTO;
using UserControlApi.Service;

namespace UserControlApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private ICadastraUsuarioService _usuarioService;
        public RegistroController(ICadastraUsuarioService usuarioService)
        {
                _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(UsuarioCadastroDTO cadastroDTO)
        {
            Result resultado = _usuarioService.CadastraUsuario(cadastroDTO);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}

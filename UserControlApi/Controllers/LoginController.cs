using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserControlApi.Model.DTO;
using UserControlApi.Service;

namespace UserControlApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginUsuarioService _loginUsuarioService;
        public LoginController(ILoginUsuarioService loginUsuarioService)
        {
            _loginUsuarioService = loginUsuarioService;
        }

        [HttpPost]
        public IActionResult LogaUsuario([FromBody] UsuarioLoginDTO loginRequest)
        {
            Result resultado = _loginUsuarioService.Login(loginRequest);
            if (resultado.IsFailed) return Unauthorized();
            
            return Ok();
        }
    }

}

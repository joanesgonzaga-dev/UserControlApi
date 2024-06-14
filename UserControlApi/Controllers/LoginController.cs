using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserControlApi.Model.DTO;
using UserControlApi.Service;

namespace UserControlApi.Controllers
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Logar([FromBody] UsuarioLoginDTO loginRequest)
        {
            Result resultado = _loginService.Logar(loginRequest);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            
            return Ok(resultado.Successes);
        }
    }

}

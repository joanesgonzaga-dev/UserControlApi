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

        [HttpPost("/solicitar-reset")]
        public IActionResult SolicitaResetSenha(UsuarioSolicitaResetarSenhaDTO senhaDTO)
        {
            var resultado = _loginService.SolicitarReset(senhaDTO);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }
    }

}

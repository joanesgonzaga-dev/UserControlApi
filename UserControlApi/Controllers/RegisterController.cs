using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserControlApi.Model.DTO;
using UserControlApi.Service;

namespace UserControlApi.Controllers
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private ISignupService _signupService;
        public RegisterController(ISignupService signupService)
        {
                _signupService = signupService;
        }

        [HttpPost]
        public IActionResult UserRegister(UsuarioCadastroDTO cadastroDTO)
        {
            Result resultado = _signupService.ToRegister(cadastroDTO);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }
    }
}

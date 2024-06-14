using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserControlApi.Service;

namespace UserControlApi.Controllers
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;
        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Result result = _logoutService.Logout();
            if (result.IsFailed) return Unauthorized(result.Errors); 
            return Ok(result.Successes);
        }
    }
}

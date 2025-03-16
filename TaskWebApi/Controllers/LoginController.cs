using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskWebApi.Models;
using TaskWebApi.Models.DTOs;
using TaskWebApi.Services;

namespace TaskWebApi.Controllers
{

    [ApiController]
    [SwaggerTag("Servicios relacionados al inicio de sesion.")]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // ✅ Iniciar sesion
        [HttpPost]
        [SwaggerOperation(summary: "Iniciar Sesion")]
        public async Task<ActionResult<bool>> Login([FromBody] LoginDto loginDto)
        {
            var result = await _loginService.Login(loginDto);
            if (result == null || !result.Exito)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}

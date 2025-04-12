using DatosNomina.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioNomina.Servicios;

namespace API_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CredencialesDTO credenciales)
        {
            var authResult = await _authService.Login(credenciales);
            if (authResult.IsLogin)
            {
                return Ok(authResult);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

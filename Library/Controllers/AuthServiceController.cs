using Library.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AuthServiceController : ControllerBase
    {
        public readonly IAuthService _authService;
        public AuthServiceController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            return await _authService.Login(login, password);
        }
    }
} 

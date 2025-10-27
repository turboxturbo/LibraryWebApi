using Library.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthServiceController
    {
        public readonly IAuthService _authService;
        public AuthServiceController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            return await _authService.Login(login, password);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Library.Interfaces
{
    public interface IAuthService
    {
        Task<IActionResult> Login(string login, string password);
    }
}

using System.Text;
using Library.DataBaseContext;
using Library.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Library.Service
{
    public class AuthSevice : IAuthService
    {
        private readonly ContextDb _contextDb;
        public AuthSevice(ContextDb context)
        {
            _contextDb = context;
        }
        private bool islogin = false;
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public async Task<IActionResult> Login(string login, string password)
        {
            var user = _contextDb.Logins.FirstOrDefault(l => l.LoginName == login && l.Password == password);
            if (user == null)
            {
                return new NotFoundObjectResult(new {status = false, message = "Такой логин не найден или неправильно введены данные" });
            }
            islogin = true;
            //var jwt = new JsonWebToken(
            //  issuer: AuthSevice.ISSUER,
            //  audience: AuthSevice.AUDIENCE,
            //    )
            return new OkObjectResult(new {message = $"Вы успешно вошли в систему, добро пожаловать, {login}", status = true});
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using qrMenu.Models;

namespace qrMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AdminUser login)
        {
            var user = _context.AdminUsers
                .FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

            if (user == null)
                return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre" });

            return Ok(new { success = true });
        }

    }
}

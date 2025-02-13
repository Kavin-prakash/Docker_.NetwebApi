using AzuerSqApi.Data;
using AzuerSqApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTokenApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : Controller
    {

        private readonly AzureSqlContext _context;
        public RegisterController(AzureSqlContext azureSqlContext)
        {
            _context = azureSqlContext;
        }

        [HttpPost]
        public IActionResult RegisterUser(UserRegisterViewModel userRegisterViewModel)
        {

            var existingUser = _context.Users.FirstOrDefault(user => user.UserEmail == userRegisterViewModel.UserEmail);

            if (existingUser == null)
            {
                var user = new User
                {
                    UserName = userRegisterViewModel.UserName,
                    UserEmail = userRegisterViewModel.UserEmail,
                    UserPassword = userRegisterViewModel.UserPassword,
                    UserRole = MessageConstants.UserMessageForRegisterPage
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok(new { userDetails = User, message = "User registered successfully" });
            }
            else
            {
                return StatusCode(409, new { message = "User already exists" });
            }
        }
    }
}

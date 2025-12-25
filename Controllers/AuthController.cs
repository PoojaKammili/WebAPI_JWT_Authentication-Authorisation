using Microsoft.AspNetCore.Mvc;
using WebAPI_JWT_Authentication_Authorisation.Model;
using WebAPI_JWT_Authentication_Authorisation.Service;

namespace WebAPI_JWT_Authentication_Authorisation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginCredentials _credentials;
        public AuthController(LoginCredentials credentials)
        {
            _credentials = credentials;
        }
        [HttpPost]
        public IActionResult createToken([FromBody]Credentials credentials)
        {
            if (credentials == null)
                return Unauthorized();

            if (credentials.Username == "Pooja" && credentials.Password == "Token123")
            {
                var token = _credentials.GenerateToken(credentials.Username, "Admin");
                return Ok(new {Token = token});
            }
            return Unauthorized();
        }
    }
}

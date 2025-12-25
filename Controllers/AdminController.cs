using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_JWT_Authentication_Authorisation.Service;

namespace WebAPI_JWT_Authentication_Authorisation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Authorisation()
        {
            return Ok("Welcome Admin");
        }
    }
}

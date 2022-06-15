using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.EmployeeAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;
        public AuthController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AuthUser([FromBody] User user)
        {
            try
            {
                var token= _jwtAuthenticationManager.Authenticate(user.userName,user.password);
                if (token==null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch
            {

                return BadRequest();
            }
        }
    }

    public class User
    {
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}

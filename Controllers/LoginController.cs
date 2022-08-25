using E_CommenceAPI.CommenceService;
using E_CommenceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using E_CommenceAPI.Helper;

namespace E_CommenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthenticationManager _authenticationManager;
        private LoginService _loginService = new LoginService();
        public LoginController(AuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [Authorize]
        [Route("ValidateUser")]
        [HttpPost]
        public OkObjectResult ValidateUser(LogIn logIn)
        {
            try
            {
                Guid userId = _loginService.ValidateUser(logIn);
                if (userId == Guid.Empty)
                    throw new Exception("Please provide the correct username and password!");
                return Ok(new ResponseObject { StatusCode = 200, Message = userId.ToString() });
            }
            catch(Exception)
            {
                return Ok(new ResponseObject { StatusCode = 401, Message = "" });
            }
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody]SysUser sysUser)
        {
            var token = _authenticationManager.Authenicate(sysUser.Username, sysUser.Password);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}

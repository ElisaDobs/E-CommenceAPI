using E_CommenceAPI.CommenceService;
using E_CommenceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private RegisterUserService registerUserService = new RegisterUserService();
        [Authorize]
        [Route("CreateUser")]
        [HttpPost]
        public OkResult CreateUser(SignIn signIn)
        {
            try
            {
                registerUserService.CreateUser(signIn);
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }
    }
}

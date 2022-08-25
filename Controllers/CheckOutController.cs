using E_CommenceAPI.CommenceService;
using E_CommenceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private UserOrderProductCheckOutService? _userOrderProductCheckOutService;
        [Route("UserProductCheckOut")]
        [HttpPost]
        public OkResult UserProductCheckOut(CheckoutProductOrder _checkoutProductOrder)
        {
            try
            {
                UserEmailService _userEmailService = new UserEmailService();
                _checkoutProductOrder.EmailAddress = _userEmailService.GetEmailAddressByUserId(Guid.Parse(_checkoutProductOrder.UserId));
                //Dependency Injection Implementation
                _userOrderProductCheckOutService = new UserOrderProductCheckOutService(new EmailNotificationService());
                _userOrderProductCheckOutService.CheckoutUserProductOrder(_checkoutProductOrder);
                return Ok();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

using E_CommenceAPI.CommenceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterProductController : ControllerBase
    {
        private RegisterProductService _registerProductService = new RegisterProductService();
        [Authorize]
        [Route("CreateProduct")]
        [HttpPost]
        public OkResult CreateProduct(
                                        string productName,
                                        string productImage,
                                        decimal productPrice,
                                        int productQuantity,
                                        int userId
                                     )
        {
            try
            {
                _registerProductService.CreateProduct(
                                                         productName,
                                                         productImage,
                                                         productPrice,
                                                         productQuantity,
                                                         userId
                                                     );
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }
    }
}

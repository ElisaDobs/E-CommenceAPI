using E_CommenceAPI.CommenceService;
using E_CommenceAPI.Models;
using E_CommenceAPI.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace E_CommenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductOrderController : ControllerBase
    {
        [Authorize]
        [Route("StoreUserProductOrder")]
        [HttpPost]
        public OkResult StoreUserProductOrder(StoreOrderNoUserProduct _storeOrderNoUserProduct)
        {
            try
            {
                RegisterOrderService _registerOrderService = new RegisterOrderService(_storeOrderNoUserProduct);
                ProductRemoveService _productRemoveService = new ProductRemoveService();
                _registerOrderService.CreateUserProductByOrderNo();
                _productRemoveService.RemoveProductFromStore(_storeOrderNoUserProduct.products.GroupedBySumProduct());
                return Ok();
            }
            catch(Exception)
            {
                return Ok();
            }
        }
    }
}

using E_CommenceAPI.CommenceService;
using E_CommenceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_CommenceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewShoppingCartController : ControllerBase
    {
        private ShoppingCartService _shoppingCartService = new ShoppingCartService();
        private ProductOrderService _productOrderService = new ProductOrderService();
        [Authorize]
        [Route("ViewShoppingCartByProductQuantity")]
        [HttpPost]
        public OkObjectResult ViewShoppingCartByProductQuantity(List<ProductQuantity> productQuantities)
        {
            try
            {
                if (productQuantities == null)
                {
                    throw new Exception("No products selected.");
                }
                var shoppingCart = _shoppingCartService.GetShoppingCart(productQuantities);
                shoppingCart.OrderNo = $"Order #{_productOrderService.GetProductPurchaseOrderNo() + 1}";
                return Ok(shoppingCart);
            }
            catch(Exception)
            {
                return Ok(new { Message = "Nothing is returned" });
            }
        }
    }
}

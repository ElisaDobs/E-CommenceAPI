using E_CommenceAPI.CommenceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductService _productService = new ProductService();
        [Authorize]
        [Route("ECommenceProducts")]
        [HttpGet]
        public OkObjectResult GetECommenceProducts()
        {
            try
            {
                return Ok(_productService.GetECommenceAllProducts());
            }
            catch(Exception)
            {
                return Ok(401);
            }
        }
    }
}
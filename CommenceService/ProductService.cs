using E_CommenceAPI.CommenceRepository;
using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    //Single Responsibility Implementation
    public class ProductService
    {
        private ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public IEnumerable<Product> GetECommenceAllProducts()
        {
            try
            {
                return _productRepository.GetAllProducts();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

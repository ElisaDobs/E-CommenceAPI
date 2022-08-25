using E_CommenceAPI.CommenceRepository;

namespace E_CommenceAPI.CommenceService
{
    //Single Responsibility Implementation
    public class RegisterProductService
    {
        private ProductRepository _productRepository;
        public RegisterProductService()
        {
            _productRepository = new ProductRepository();
        }
        public void CreateProduct(
                                    string productName,  
                                    string productImagePath, 
                                    decimal productPrice, 
                                    int productQuantity,
                                    int userId
                                 )
        {
            try
            {
                _productRepository.CreateProduct(
                                                    productName, 
                                                    productImagePath, 
                                                    productPrice,
                                                    productQuantity,
                                                    userId
                                                );
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

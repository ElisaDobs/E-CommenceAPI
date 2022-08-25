using E_CommenceAPI.CommenceRepository;
using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    public class ProductRemoveService
    {
        private OrderRepository _orderRepository;
        public ProductRemoveService()
        {
            _orderRepository = new OrderRepository();
        }
        public void RemoveProductFromStore(IEnumerable<ProductQuantity> productQuantities)
        {
            try
            {
                _orderRepository.RemoveProductOrderFromStock(productQuantities);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

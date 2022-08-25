using E_CommenceAPI.CommenceRepository;

namespace E_CommenceAPI.CommenceService
{
    public class ProductOrderService
    {
        private OrderRepository _orderRepository;
        public ProductOrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public int GetProductPurchaseOrderNo()
        {
           try
            {
                return _orderRepository.GetLastOrderId();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

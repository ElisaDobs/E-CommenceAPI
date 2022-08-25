using E_CommenceAPI.CommenceRepository;

namespace E_CommenceAPI.CommenceService
{
    //Single and Interface Segregation Responsibility Implementations
    public class RegisterOrderService
    {
        private OrderRepository _orderRepository = new OrderRepository();

        private IStoreOrderNoUserProduct _storeOrderNoUserProduct;
        public RegisterOrderService(IStoreOrderNoUserProduct storeOrderNoUserProduct)
        {
            _storeOrderNoUserProduct = storeOrderNoUserProduct;
        }
        public void CreateUserProductByOrderNo()
        {
            if (_storeOrderNoUserProduct != null)
            {
                _orderRepository.CreateUserOrderProduct(
                                                            _storeOrderNoUserProduct.products, 
                                                            _storeOrderNoUserProduct.userId, 
                                                            _storeOrderNoUserProduct.orderNo
                                                       );
            }
        }
    }
}

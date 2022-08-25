using E_CommenceAPI.Models;
using E_CommenceAPI.DAL;

namespace E_CommenceAPI.CommenceRepository
{
    public class OrderRepository
    {
        private UserRepository _userRepository;
        public OrderRepository()
        {
            _userRepository = new UserRepository();
        }
        public void CreateUserOrderProduct(List<int> products, string userId, string orderNo)
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                products.ForEach(delegate (int productId)
                {
                    eCommenceDBContext.ProductOrders.Add(new ProductOrder()
                    {
                        UserId = (int)_userRepository.GetUserByUserGuid(Guid.Parse(userId)),
                        OrderNo = orderNo,
                        ProductId = productId,
                        OrderSequence = Convert.ToInt32(orderNo.Substring(orderNo.IndexOf("#") + 1)),
                        DateCreated = DateTime.Now
                    });
                    eCommenceDBContext.SaveChanges();
                });
            }
        }

        public void RemoveProductOrderFromStock(IEnumerable<ProductQuantity> productQuantities)
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                foreach (ProductQuantity productQuantity in productQuantities)
                {
                    var productOrder = eCommenceDBContext.Products.FirstOrDefault(a => a.ProductId == productQuantity.ProductId);
                    if (productOrder != null)
                    {
                        if (productOrder.ProductQuantity >= productQuantity.Quantity)
                        {
                            productOrder.ProductQuantity -= productQuantity.Quantity;
                            eCommenceDBContext.SaveChanges();
                        }
                    }
                }
            }
        }
        public int GetLastOrderId()
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                if (eCommenceDBContext.ProductOrders.Count() > 0)
                {
                    var orderSequence = eCommenceDBContext.ProductOrders.Max(x => x.OrderSequence);

                    return orderSequence;
                }
                return 0;
            }
        }
    }
}

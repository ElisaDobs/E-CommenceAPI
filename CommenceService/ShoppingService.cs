using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    public abstract class ShoppingService
    {
        public abstract ShoppingCart GetShoppingCart(IEnumerable<ProductQuantity> products);
    }
}

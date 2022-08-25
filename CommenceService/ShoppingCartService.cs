using E_CommenceAPI.CommenceRepository;
using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    //Open - Close Responsibility Implementation
    public class ShoppingCartService : ShoppingService
    {
        private ProductRepository _productRepository;
        public ShoppingCartService() { 
            _productRepository = new ProductRepository();
        }

        public override ShoppingCart GetShoppingCart(IEnumerable<ProductQuantity> products)
        {
            try
            {
                ShoppingCart cart = new ShoppingCart();
                cart.ShoppingCarts = new List<ShoppingCartProduct>();
                foreach (ProductQuantity product in products)
                {
                    var shoppingCart = _productRepository.GetShoppingCartProductByProductId(product.ProductId);
                    if (shoppingCart != null)
                    {
                        shoppingCart.ProductQuantity = product.Quantity;
                        shoppingCart.ProductPrice = shoppingCart.ProductPrice * product.Quantity;
                        cart.ShoppingCarts.Add(shoppingCart);
                        cart.TotalProductPrice += shoppingCart.ProductPrice;
                    }
                }
                return cart;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

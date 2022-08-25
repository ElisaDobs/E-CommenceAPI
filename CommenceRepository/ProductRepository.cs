using E_CommenceAPI.Models;
using E_CommenceAPI.DAL;

namespace E_CommenceAPI.CommenceRepository
{
    public class ProductRepository
    {
        public ProductRepository()
        {

        }
        public void CreateProduct(
                                    string productName,
                                    string productImagePath,
                                    decimal productPrice,
                                    int productQuantity,
                                    int userId
                                 )
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                Product product = new Product()
                {
                    ProductName = productName,
                    CreatedBy_UserId = userId,
                    ProductImage = productImagePath,
                    ProductPrice = productPrice,
                    ProductQuantity = productQuantity,
                    DateCreated = DateTime.Now
                };
                eCommenceDBContext.Products.Add(product);
                eCommenceDBContext.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                var products = eCommenceDBContext.Products.ToList();

                return products;
            }
        }

        public ShoppingCartProduct? GetShoppingCartProductByProductId(int productId)
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                var shoppingCartProduct = eCommenceDBContext.Products
                                                            .Where(a => a.ProductId == productId)
                                                            .Select(a => new ShoppingCartProduct {
                                                                ProductName = a.ProductName,
                                                                ProductPrice = a.ProductPrice,
                                                                ProductQuantity = a.ProductQuantity,
                                                            })
                                                            .FirstOrDefault();
                if (shoppingCartProduct == null) return default(ShoppingCartProduct);

                return shoppingCartProduct;
            }
        }
    }
}

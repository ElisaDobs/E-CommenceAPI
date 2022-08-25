using E_CommenceAPI.Common;
using E_CommenceAPI.CommenceRepository;
using System.Text;

namespace E_CommenceAPI.Helper
{
    public static class EmailHelper
    {
        public static string EmailBodyBuilder(IEnumerable<int> products, string orderNo)
        {
            ProductRepository _productRepository = new ProductRepository();
            StringBuilder html = new StringBuilder();
            html.Append("<div>");
            html.Append("<div>");
            html.Append($"<span style=\"font-weight:bold;\">{orderNo}</span>");
            html.Append("</div>");
            html.Append("<div><table>");
            html.Append("<thead><tr><th>Product</th><th>Quantity</th><th>Price</th></tr></thead><tbody>");
            foreach (var product in products.GroupedBySumProduct())
            {
                var ShoppingCart = _productRepository.GetShoppingCartProductByProductId(product.ProductId);
                decimal product_price = (decimal)(ShoppingCart?.ProductPrice * product.Quantity);
                html.Append($"<tr><td>{ShoppingCart?.ProductName}</td><td>{product.Quantity}</td><td>{product_price.ToString("C")}</td></tr>");
            }
            html.Append("<tbody></table></div>");
            html.Append("</div>");

            return html.ToString();
        }
    }
}

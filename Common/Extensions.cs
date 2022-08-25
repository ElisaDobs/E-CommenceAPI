using E_CommenceAPI.Models;

namespace E_CommenceAPI.Common
{
    public static class Extensions
    {
        public static IEnumerable<ProductQuantity> GroupedBySumProduct(this List<int> products)
        {
            IEnumerable<ProductQuantity> _productQuantities = products.Select(a => new ProductQuantity { ProductId = a, Quantity = 1 })
                                                 .GroupBy(x => x.ProductId)
                                                 .Select(y => new ProductQuantity { ProductId = y.Key, Quantity = y.Sum(x => x.Quantity) }).ToList();
            return _productQuantities;

        }

        public static IEnumerable<ProductQuantity> GroupedBySumProduct(this IEnumerable<int> products)
        {
            IEnumerable<ProductQuantity> _productQuantities = products.Select(a => new ProductQuantity { ProductId = a, Quantity = 1 })
                                                 .GroupBy(x => x.ProductId)
                                                 .Select(y => new ProductQuantity { ProductId = y.Key, Quantity = y.Sum(x => x.Quantity) }).ToList();
            return _productQuantities;

        }
    }
}

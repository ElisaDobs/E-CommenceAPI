namespace E_CommenceAPI.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartProduct> ShoppingCarts { get; set; }
        public decimal TotalProductPrice { get; set; }
        public string OrderNo { get; set; }
    }
}

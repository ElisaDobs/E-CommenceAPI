namespace E_CommenceAPI.Models
{
    public class CheckoutProductOrder
    {
        public string EmailAddress { get; set; }
        public IEnumerable<int> Products { get; set; }
        public string OrderNo { get; set; }
        public string UserId { get; set; }
    }
}

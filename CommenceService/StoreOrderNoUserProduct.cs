using E_CommenceAPI.Models;
using E_CommenceAPI.CommenceRepository;

namespace E_CommenceAPI.CommenceService
{
    public class StoreOrderNoUserProduct : IStoreOrderNoUserProduct
    {
        
        public List<int> products { get; set; }
        public string userId { get; set; }
        public string orderNo { get; set; }
    }
}

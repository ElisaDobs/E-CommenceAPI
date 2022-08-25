using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    public interface IBaseStoreUserProduct
    {
        List<int> products { get; set; }
        string userId { get; set; }
    }
}

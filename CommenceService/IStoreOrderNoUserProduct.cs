namespace E_CommenceAPI.CommenceService
{
    public interface IStoreOrderNoUserProduct : IBaseStoreUserProduct
    {
        string orderNo { get; set; }
    }
}

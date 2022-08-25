using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    public abstract class NotificationService
    {
        public abstract bool SendNotification(CheckoutProductOrder _checkoutProductOrder);
    }
}

using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    //Dependency Injection Implementation 
    public class UserOrderProductCheckOutService
    {
        public readonly NotificationService _notificationService;
        public UserOrderProductCheckOutService(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public void CheckoutUserProductOrder(CheckoutProductOrder _checkoutProductOrder)
        {
            _notificationService.SendNotification(_checkoutProductOrder);
        }
    }
}

using System.Net;
using System.Net.Mail;
using E_CommenceAPI.Models;
using E_CommenceAPI.Common;
using E_CommenceAPI.Helper;

namespace E_CommenceAPI.CommenceService
{
    //Liskov Substitution Responsibility.
    public class EmailNotificationService : NotificationService
    {
        private string _mailServer;
        private string _fromEmail;
        private string _fromPassword;
        private string _userName;
        private int _port;
        public EmailNotificationService()
        {
            _mailServer = ECommenceConfigurationManager.GetSMTPServerInfo("Server");
            _fromEmail = ECommenceConfigurationManager.GetSMTPServerInfo("FromAddress");
            _fromPassword = ECommenceConfigurationManager.GetSMTPServerInfo("Password");
            _userName = ECommenceConfigurationManager.GetSMTPServerInfo("UserName");
            _port = ECommenceConfigurationManager.GetSMTPServerPort("Port");
        }
        public override bool SendNotification(CheckoutProductOrder _checkoutProductOrder)
        {
            try
            {
                using (MailMessage mm = new MailMessage(_fromEmail, _checkoutProductOrder.EmailAddress))
                {
                    mm.Subject = "E-Commence Check out";
                    mm.Body = EmailHelper.EmailBodyBuilder(
                                                            _checkoutProductOrder.Products, 
                                                            _checkoutProductOrder.OrderNo
                                                          );
                    mm.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = _mailServer;
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(_userName, _fromPassword);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = _port;
                        smtp.Send(mm);
                    }
                }
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

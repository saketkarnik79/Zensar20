using System.Net.Mail;

namespace DemoCopilotSOLID.Services
{
    public class SmtpNotificationService : INotificationService
    {
        private readonly string _smtpHost;
        private readonly string _fromAddress;

        public SmtpNotificationService(string smtpHost, string fromAddress)
        {
            _smtpHost = smtpHost ?? throw new ArgumentNullException(nameof(smtpHost));
            _fromAddress = fromAddress ?? throw new ArgumentNullException(nameof(fromAddress));
        }

        public void SendOrderConfirmation(Order order, decimal total)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            using var smtp = new SmtpClient(_smtpHost);
            smtp.Send(_fromAddress, order.CustomerEmail, "Order Confirmation", $"Your order total is {total:C}");
        }
    }
}
namespace DemoCopilotSOLID.Services
{
    public interface INotificationService
    {
        void SendOrderConfirmation(Order order, decimal total);
    }
}
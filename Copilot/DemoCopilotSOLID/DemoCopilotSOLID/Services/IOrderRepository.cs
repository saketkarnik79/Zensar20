namespace DemoCopilotSOLID.Services
{
    public interface IOrderRepository
    {
        void Save(Order order, decimal total);
    }
}
namespace DemoCopilotSOLID.Services
{
    public interface IOrderCalculator
    {
        decimal CalculateTotal(Order order);
    }
}
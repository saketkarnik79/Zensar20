namespace DemoCopilotSOLID.Services
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public int Priority => 0;

        public bool IsApplicable(Order order) => true;

        public decimal Apply(decimal total, Order order) => total;
    }
}
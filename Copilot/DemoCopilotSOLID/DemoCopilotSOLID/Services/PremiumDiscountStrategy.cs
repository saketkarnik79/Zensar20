using System;

namespace DemoCopilotSOLID.Services
{
    public class PremiumDiscountStrategy : IDiscountStrategy
    {
        public int Priority => 100;

        public bool IsApplicable(Order order) =>
            string.Equals(order?.CustomerType, "Premium", StringComparison.OrdinalIgnoreCase);

        public decimal Apply(decimal total, Order order) => total * 0.9m;
    }
}
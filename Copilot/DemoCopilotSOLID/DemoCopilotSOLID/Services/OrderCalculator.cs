using System;
using System.Linq;
using System.Collections.Generic;

namespace DemoCopilotSOLID.Services
{
    public class OrderCalculator : IOrderCalculator
    {
        private readonly IEnumerable<IDiscountStrategy> _discountStrategies;

        public OrderCalculator(IEnumerable<IDiscountStrategy> discountStrategies)
        {
            _discountStrategies = discountStrategies ?? throw new ArgumentNullException(nameof(discountStrategies));
        }

        public decimal CalculateTotal(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (order.Items == null) return 0m;

            decimal total = order.Items.Sum(i => i.Price * i.Quantity);

            var strategy = _discountStrategies
                .OrderByDescending(s => s.Priority)
                .FirstOrDefault(s => s.IsApplicable(order));

            if (strategy != null)
            {
                total = strategy.Apply(total, order);
            }

            return total;
        }
    }
}
namespace DemoCopilotSOLID.Services
{
    public class OrderService
    {
        private readonly IOrderCalculator _calculator;
        private readonly IOrderRepository _repository;
        private readonly INotificationService _notifier;

        public OrderService(IOrderCalculator calculator, IOrderRepository repository, INotificationService notifier)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
        }

        public void ProcessOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            // Calculate total
            decimal total = _calculator.CalculateTotal(order);

            // Persist
            _repository.Save(order, total);

            // Notify
            _notifier.SendOrderConfirmation(order, total);
        }
    }
}
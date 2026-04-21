
namespace DemoMinimalWebAPIUsingGitHubCopilot
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = default!;
        public OrderItem[] Items { get; set; } = Array.Empty<OrderItem>();
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

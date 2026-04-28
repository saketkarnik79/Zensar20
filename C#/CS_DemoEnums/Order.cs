namespace CS_DemoEnums
{
    public class Order
    {
        public int OrderId { get; set; } // Auto implemented property

        public OrderStatus Status { get; set; } // Auto implemented property

        public void PrintStatus()
        {
            Console.WriteLine($"Order Status: {Status}, with value: {(int)Status}");
        }
    }
}
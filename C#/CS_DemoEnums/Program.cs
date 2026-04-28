using System;

namespace CS_DemoEnums
{
    class Program
    {
        static void ProcessOrder(Order order)
        {
            switch (order.Status)
            {
                case OrderStatus.Pending:
                    Console.WriteLine("Order is awaiting confirmation.");
                    break;
                case OrderStatus.Confirmed:
                    Console.WriteLine("Order has been confirmed.");
                    break;
                case OrderStatus.Shipped:
                    Console.WriteLine("Order is on the way.");
                    break;
                case OrderStatus.Delivered:
                    Console.WriteLine("Order has been delivered successfully.");
                    break;
                case OrderStatus.Cancelled:
                    Console.WriteLine("Order was cancelled.");
                    break;
                default:
                    Console.WriteLine("Unknown order status.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Order order = new Order()
            {
                OrderId = 1001,
                Status = OrderStatus.Pending
            };

            order.PrintStatus();

            // Change order status
            order.Status = OrderStatus.Confirmed;
            order.PrintStatus();

            // Change order status again using string input
            //order.Status = "Shipped"; // Not possible
            if (Enum.TryParse("Shipped", out OrderStatus parsedStatus))
            {
                order.Status = parsedStatus;
            }
            else
            {
                Console.WriteLine("Invalid order status received. Exiting program...");
                return;
            }
            order.PrintStatus();

            // Process based on enum value
            ProcessOrder(order);
        }
    }
}

namespace DemoMinimalWebAPIUsingGitHubCopilot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // In-memory thread-safe store for orders
            var orders = new System.Collections.Concurrent.ConcurrentDictionary<Guid, Order>();

            // Create a minimal API endpoint for creating an order
            app.MapPost("/orders", (OrderCreateDto dto) =>
            {
                // Basic validation
                if (dto is null)
                {
                    return Results.BadRequest(new { Error = "Request body is required." });
                }

                if (string.IsNullOrWhiteSpace(dto.CustomerName))
                {
                    return Results.BadRequest(new { Error = "CustomerName is required." });
                }

                if (dto.Items != null)
                {
                    foreach (var item in dto.Items)
                    {
                        if (string.IsNullOrWhiteSpace(item.ProductId))
                            return Results.BadRequest(new { Error = "Each item must have a ProductId." });
                        if (item.Quantity <= 0)
                            return Results.BadRequest(new { Error = "Each item must have Quantity > 0." });
                        if (item.Price < 0)
                            return Results.BadRequest(new { Error = "Each item must have Price >= 0." });
                    }
                }

                var items = dto.Items?.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToArray() ?? Array.Empty<OrderItem>();

                var total = items.Sum(i => i.Price * i.Quantity);

                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    CustomerName = dto.CustomerName,
                    Items = items,
                    Total = total,
                    CreatedAt = DateTime.UtcNow
                };

                orders[order.Id] = order;

                var location = $"/orders/{order.Id}";
                return Results.Created(location, order);
            })
            .WithName("CreateOrder")
            .WithOpenApi();

            app.Run();
        }
    }

    // DTOs and models
    public record OrderCreateDto(string CustomerName, OrderItemDto[]? Items);

    public record OrderItemDto(string ProductId, int Quantity, decimal Price);

    public class OrderItem
    {
        public string ProductId { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    // Placeholder WeatherForecast to keep the original endpoint compiling if not present elsewhere.
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }
}

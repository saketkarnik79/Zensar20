
using Web_DemoMinimalWebAPI.Models;

namespace Web_DemoMinimalWebAPI
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

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            List<Person> people = new List<Person>()
            {
                new Person() { Id = 1, Name = "Alice", Age = 30 },
                new Person() { Id = 2, Name = "Bob", Age = 25 },
                new Person() { Id = 3, Name = "Charlie", Age = 35 },
                new Person() { Id = 4, Name = "Diana", Age = 28 },
                new Person() { Id = 5, Name = "Ethan", Age = 40 }
            };


            app.MapGet("/people", (HttpContext httpContext) => people)
            .WithName("GetPeopleData")
            .WithOpenApi();

            app.Run();
        }
    }
}

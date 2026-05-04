using Microsoft.EntityFrameworkCore;
using Web_DemoWebAPIWithEFCore.Infrastructure.Data;
using Web_DemoWebAPIWithEFCore.Application.Repositories;
using Web_DemoWebAPIWithEFCore.Infrastructure.Repositories;
using Web_DemoWebAPIWithEFCore.Application.UnitOfWork;
using Web_DemoWebAPIWithEFCore.Infrastructure.UnitOfWork;
using Web_DemoWebAPIWithEFCore.Models;

namespace Web_DemoWebAPIWithEFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options => 
            { 
                options.UseInMemoryDatabase("DemoDb");
            });

            builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddControllers();
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


            app.MapControllers();

            app.Run();
        }
    }
}

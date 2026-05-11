using Microsoft.EntityFrameworkCore;
using AZ_DemoSQLAzure.Data;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AZ_DemoSQLAzure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var keyVaultUri = new Uri("https://oizenkv.vault.azure.net/");
            var secretClient = new SecretClient(keyVaultUri, new DefaultAzureCredential());
            var secret = secretClient.GetSecret("DBConnection");


            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options => 
            {
                //options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                options.UseSqlServer(secret.Value.Value);
            });
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

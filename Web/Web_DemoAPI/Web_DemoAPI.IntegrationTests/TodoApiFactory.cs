using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DemoAPI.Repositories;
using Web_DemoAPI.Services;

namespace Web_DemoAPI.IntegrationTests
{
    public class TodoApiFactory: WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => 
            {
                services.AddSingleton<ITodoRepository, TodoRepository>();
            });
        }
    }
}

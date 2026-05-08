using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ZenDemoFuncApp;

public class MyHttpFunction
{
    private readonly ILogger<MyHttpFunction> _logger;

    public MyHttpFunction(ILogger<MyHttpFunction> logger)
    {
        _logger = logger;
    }

    [Function("MyHttpFunction")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        // Retrieve query parameters
        string name = req.Query["name"]!;

        if (string.IsNullOrEmpty(name))
        {
            // Read the request body if the name is not in the query string
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if (!string.IsNullOrEmpty(requestBody))
            {
                name = requestBody;
            }
        }

        if (!string.IsNullOrEmpty(name)) 
        { 
            return new OkObjectResult($"Hello, {name}. this HTTP triggered function executed successfully!");
        }
        else
        {
            return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
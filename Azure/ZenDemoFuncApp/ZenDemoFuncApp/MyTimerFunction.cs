using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ZenDemoFuncApp;

public class MyTimerFunction
{
    private readonly ILogger _logger;

    public MyTimerFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<MyTimerFunction>();
    }

    [Function("MyTimerFunction")]
    public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer) // Runs every 1 minute
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        
        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }

        // Add your business logic here
        Console.WriteLine("Executing scheduled job...");
    }
}
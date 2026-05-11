using AZ_DemoStorageQueue.Queing;

namespace AZ_DemoStorageQueue
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
			try
			{
				var queueStorageService = new QueueStorageService();
				await queueStorageService.RunAsync();

				Console.WriteLine("All queue operations completed!");
				Console.WriteLine("Program completed. Press any key to exit...");
				Console.ReadKey();
			}
			catch (Exception ex)
			{
                Console.WriteLine($"Error: {ex.Message}");
			}
        }
    }
}

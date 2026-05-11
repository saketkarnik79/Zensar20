using AZ_DemoCosmosDB.Services;

namespace AZ_DemoCosmosDB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
			try
			{
				var demoCosmos = new CosmosDBService();
				await demoCosmos.RunAsync();

				Console.WriteLine("All CosmosDB operation completed...");
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

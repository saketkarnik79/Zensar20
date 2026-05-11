using AZ_TableStorage.Data;

namespace AZ_TableStorage
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                TableStorageOps tableStorageOps = new TableStorageOps();
                await tableStorageOps.RunAsync();

                Console.WriteLine("All operations completed successfully.");
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

namespace CS_DemoAsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application started...");

            try
            {
                var service = new UserService();
                User? user = await service.GetAndSaveUserAsync(1);

                if (user != null)
                {
                    Console.WriteLine($"User details saved: ID={user.id}, Name={user.name}, Email={user.email}");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.WriteLine("Application ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}

using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient.Protos;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7005");

            var client = new Greeter.GreeterClient(channel);
            var calcClient = new Calc.CalcClient(channel);

            //var reply = await client.SayHelloAsync(new HelloRequest { Name = "Saket" });
            //var reply2 = await client.SayWelcomeAsync(new HelloRequest { Name = "James" });

            //Console.WriteLine(reply.Message);
            //Console.WriteLine(reply2.Message);

            var call = client.SayHelloStream(new HelloRequest { Name = "Saket" });
            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(response.Message);
            }

            var calcReply = await calcClient.AddAsync(new CalcRequest { Num1 = 5, Num2 = 3 });
            Console.WriteLine($"Addition Result: {calcReply.Result}");

            Console.WriteLine("Program completed. Press any key to stop the server...");
            Console.ReadKey();
        }
    }
}

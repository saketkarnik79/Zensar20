using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override async Task SayHelloStream(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            for (int i = 1; i <= 5; i++)
            {
                await responseStream.WriteAsync(new HelloReply
                {
                    Message = $"Hello, {request.Name}! This is message {i} from gRPC server."
                });
                await Task.Delay(1000); // Simulate some delay between messages
            }
        }

        //public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        //{
        //    return Task.FromResult(new HelloReply
        //    {
        //        Message = $"Hello, {request.Name}! From gRPC server."
        //    });
        //}

        //public override Task<HelloReply> SayWelcome(HelloRequest request, ServerCallContext context)
        //{
        //    return Task.FromResult(new HelloReply
        //    {
        //        Message = $"Welcome, {request.Name}! From gRPC server."
        //    });
        //}
    }
}

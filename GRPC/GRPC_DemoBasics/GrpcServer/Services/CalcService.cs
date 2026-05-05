using Grpc.Core;
using GrpcServer.Protos;

namespace GrpcServer.Services
{
    public class CalcService: Calc.CalcBase
    {
        public override Task<CalcReply> Add(CalcRequest request, ServerCallContext context)
        {
            var result = request.Num1 + request.Num2;
            return Task.FromResult(new CalcReply { Result = result });
        }
    }
}

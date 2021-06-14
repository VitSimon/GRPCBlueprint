using Greeter;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPCServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 5555;
            Server server = new Server
            {
                Services = { Greet.BindService(new GreetImpl()) },
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine($"Greeter Server Listening on port {port}");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();

            server.ShutdownAsync().Wait();
        }
    }


    class GreetImpl : Greet.GreetBase
    {
        static Random ran = new Random();

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = $"Hello {request.Name}" });
        }

        public override Task<TimeReply> GetTime(TimeRequest request, ServerCallContext context)
        {
            return Task.FromResult(new TimeReply { Stamp = DateTime.Now.Ticks });
        }

        public override async Task GetRandomNumber(RanNumRequest request, IServerStreamWriter<RanNumReply> responseStream, ServerCallContext context)
        {
            int i = 0;

            while (
                //!context.CancellationToken.IsCancellationRequested || 
                i < 20)
            {
                //await Task.Delay(300);

                RanNumReply reply = new RanNumReply
                {
                    Num = ran.Next(200)
                };

                await responseStream.WriteAsync(reply);
                i++;
            }

        }
    }
}
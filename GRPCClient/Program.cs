using Greeter;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:5555", ChannelCredentials.Insecure);
            var client = new Greet.GreetClient(channel);
            var replay = client.SayHello(new HelloRequest { Name = "Auto" });
            Console.WriteLine($"{replay.Message}");

            var replayTime = client.GetTime(new TimeRequest());
            Console.WriteLine($"Time is: {new DateTime(replayTime.Stamp)}");

            channel.ShutdownAsync().Wait();
            Console.ReadLine();
        }
    }
}

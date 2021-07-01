//Zdroj: https://www.programmersought.com/article/73167383948/
using Greeter;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GRPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:5555", ChannelCredentials.Insecure);
            var client = new Greet.GreetClient(channel);
            CallOptions o = new CallOptions();
            var reply = client.SayHello(new HelloRequest { Name = "Auto" }, o);
            Console.WriteLine($"{reply.Message}");

            var replyTime = client.GetTime(new TimeRequest());
            Console.WriteLine($"Time is: {new DateTime(replyTime.Stamp)}");

            {
                Task t = GetNumbers(client);
                t.Wait();
            };

            List<long> requests = new List<long>() { 3, 5, 10 };

            using (var call = client.GetFactorial())
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        FactorialReply far = call.ResponseStream.Current;
                        Console.WriteLine("Base {0}: mid number {1}", far.BaseNum, far.Num);
                    }
                });

                foreach (long request in requests)
                {
                    FactorialRequest fare = new FactorialRequest() { Num = request };

                    call.RequestStream.WriteAsync(fare).Wait();
                }
                call.RequestStream.CompleteAsync().Wait();
                responseReaderTask.Wait();
            }

            new OneReqOneResp<HelloReply>()
            {
                Handler = (HelloReply r) =>
                Console.WriteLine("Handling class:" + r.Message)
            }.SendRequest(
                () =>
                {
                    return client.SayHello(
                        new HelloRequest() { Name = "Testicek" }
                        );
                }
            );

            new OneReqMoreResp<RanNumReply>()
            {
                Handler = (RanNumReply r) =>
                {
                    Console.WriteLine("Handling class: number: " + r.Num);
                }
            }.SendRequest(
            () =>
            {
                return client.GetRandomNumber(new RanNumRequest());
            }
            );

            new MoreReqMoreResp<FactorialRequest, FactorialReply>(
                () =>
                {
                    return client.GetFactorial();
                }
                )
            {
                Handler = (FactorialReply r) =>
                {
                    Console.WriteLine("Handling class: factorial: " + r.Num);
                }
            }.SendRequest(
                new FactorialRequest()
                {
                    Num = 5
                }
            );

            channel.ShutdownAsync().Wait();

            Console.ReadLine();
        }

        private static async Task GetNumbers(Greet.GreetClient client)
        {
            //var cts = new CancellationTokenSource(15000);
            //, cancellationToken: cts.Token
            try
            {
                using (AsyncServerStreamingCall<RanNumReply> streamingCall = client.GetRandomNumber(new RanNumRequest()))
                {
                    await Task.Delay(1000);
                    //while (streamingCall.GetStatus().StatusCode != Grpc.Core.StatusCode.Cancelled)
                    //{
                    while (await streamingCall.ResponseStream.MoveNext())
                    {
                        Console.WriteLine($"Number is: {streamingCall.ResponseStream.Current.Num}");
                    }
                    //    Thread.Sleep(5000);
                    //}
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                Console.WriteLine("Stream cancelled.");
            }
        }
    }
}
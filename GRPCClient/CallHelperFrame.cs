using Grpc.Core;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GRPCClient
{
    public abstract class CallHelperFrame<Response>
    {
        public Action<Response> Handler { get; set; }

        public CallHelperFrame()
        {
        }

        protected void PassToProcessor(Response resp)
        {
            ProcessResponse(resp);
        }

        /*protected async void PassToProcessor(AsyncServerStreamingCall<Response> resp)
        {
            while (await resp.ResponseStream.MoveNext(default))
            {
                ProcessResponse(resp.ResponseStream.Current);
            }
        }

        protected async void PassToProcessor(AsyncDuplexStreamingCall<Request, Response> resp)
        {
            while (await resp.ResponseStream.MoveNext(default))
            {
                ProcessResponse(resp.ResponseStream.Current);
            }
        }*/

        protected async void PassToProcessor(IAsyncStreamReader<Response> resp)
        {
            try
            {
                while (await resp.MoveNext(default))
                {
                    ProcessResponse(resp.Current);
                }
            }
            catch (Grpc.Core.RpcException e)
            {
                if (e.StatusCode != StatusCode.Cancelled)
                    throw;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessResponse(Response resp)
        {
            Handler.Invoke(resp);
        }
    }

    public class OneReqOneResp<Response> : CallHelperFrame<Response>
    {
        public void SendRequest(Func<Response> ResponseFunc)
        {
            Response re = ResponseFunc();
            this.PassToProcessor(re);
        }
    }

    public class OneReqMoreResp<Response> : CallHelperFrame<Response>
    {
        public void SendRequest(Func<AsyncServerStreamingCall<Response>> ResponseFunc)
        {
            using (AsyncServerStreamingCall<Response> streamingCall = ResponseFunc())
            {
                PassToProcessor(streamingCall.ResponseStream);
            }
        }
    }

    public class MoreReqMoreResp<Request, Response> : CallHelperFrame<Response>, IDisposable
    {
        protected AsyncDuplexStreamingCall<Request, Response> call;
        protected Task responseReaderTask;

        public MoreReqMoreResp(Func<AsyncDuplexStreamingCall<Request, Response>> ResponseFunc)
        {
            call = ResponseFunc();
        }

        public void Dispose()
        {
            ResetResponseTask();

            if (call != null)
            {
                call.RequestStream.CompleteAsync().Wait();
                call.Dispose();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void ResetResponseTask()
        {
            if (responseReaderTask != null && responseReaderTask.Status == TaskStatus.Running)
                responseReaderTask.Wait();
        }

        public void SendRequest(Request request)
        {
            ResetResponseTask();

            responseReaderTask = Task.Run(() =>
            {
                //if (call.GetStatus().StatusCode == StatusCode.Cancelled)
                //    return;

                PassToProcessor(call.ResponseStream);
            });

            call.RequestStream.WriteAsync(request);
        }
    }
}
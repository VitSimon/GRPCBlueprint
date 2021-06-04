// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Greeter.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Greeter {
  public static partial class Greet
  {
    static readonly string __ServiceName = "Greeter.Greet";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Greeter.HelloRequest> __Marshaller_Greeter_HelloRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Greeter.HelloRequest.Parser));
    static readonly grpc::Marshaller<global::Greeter.HelloReply> __Marshaller_Greeter_HelloReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Greeter.HelloReply.Parser));
    static readonly grpc::Marshaller<global::Greeter.TimeRequest> __Marshaller_Greeter_TimeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Greeter.TimeRequest.Parser));
    static readonly grpc::Marshaller<global::Greeter.TimeReply> __Marshaller_Greeter_TimeReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Greeter.TimeReply.Parser));

    static readonly grpc::Method<global::Greeter.HelloRequest, global::Greeter.HelloReply> __Method_SayHello = new grpc::Method<global::Greeter.HelloRequest, global::Greeter.HelloReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SayHello",
        __Marshaller_Greeter_HelloRequest,
        __Marshaller_Greeter_HelloReply);

    static readonly grpc::Method<global::Greeter.TimeRequest, global::Greeter.TimeReply> __Method_GetTime = new grpc::Method<global::Greeter.TimeRequest, global::Greeter.TimeReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetTime",
        __Marshaller_Greeter_TimeRequest,
        __Marshaller_Greeter_TimeReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Greeter.GreeterReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Greet</summary>
    [grpc::BindServiceMethod(typeof(Greet), "BindService")]
    public abstract partial class GreetBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Greeter.HelloReply> SayHello(global::Greeter.HelloRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Greeter.TimeReply> GetTime(global::Greeter.TimeRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Greet</summary>
    public partial class GreetClient : grpc::ClientBase<GreetClient>
    {
      /// <summary>Creates a new client for Greet</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public GreetClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Greet that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public GreetClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected GreetClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected GreetClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Greeter.HelloReply SayHello(global::Greeter.HelloRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayHello(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Greeter.HelloReply SayHello(global::Greeter.HelloRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SayHello, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Greeter.HelloReply> SayHelloAsync(global::Greeter.HelloRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayHelloAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Greeter.HelloReply> SayHelloAsync(global::Greeter.HelloRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SayHello, null, options, request);
      }
      public virtual global::Greeter.TimeReply GetTime(global::Greeter.TimeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetTime(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Greeter.TimeReply GetTime(global::Greeter.TimeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetTime, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Greeter.TimeReply> GetTimeAsync(global::Greeter.TimeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetTimeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Greeter.TimeReply> GetTimeAsync(global::Greeter.TimeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetTime, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override GreetClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GreetClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GreetBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SayHello, serviceImpl.SayHello)
          .AddMethod(__Method_GetTime, serviceImpl.GetTime).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GreetBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SayHello, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Greeter.HelloRequest, global::Greeter.HelloReply>(serviceImpl.SayHello));
      serviceBinder.AddMethod(__Method_GetTime, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Greeter.TimeRequest, global::Greeter.TimeReply>(serviceImpl.GetTime));
    }

  }
}
#endregion

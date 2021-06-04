exit
echo batak
dir
cd ..\..\
dir
..\packages\Grpc.Tools.2.38.0\tools\windows_x64\protoc.exe -IPATH . "--csharp_out="
rem -I ".\" --csharp_out Greeter GRPCDemo2\Greeter.proto --grpc_out Greeter --plugin=protoc-gen-grpc=..\packages\Grpc.Tools.2.32.0\tools\windows_x64\grpc_csharp_plugin.exe
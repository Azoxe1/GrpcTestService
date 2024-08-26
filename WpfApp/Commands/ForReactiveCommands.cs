using Grpc.Net.Client;
using System.Net.Http;
using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp.Commands
{
    
    internal class ForReactiveCommands 
    {
        private static readonly AddModelViewModel _AddModelViewModel;

        private static string ServiceAddress = "https://localhost:7136";
        private static HttpClientHandler GetHttpHandler()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            return httpHandler;
        }

        public static GrpcChannel GetChannel()
        {
            return GrpcChannel.ForAddress(ServiceAddress, new GrpcChannelOptions
            {
                HttpHandler = GetHttpHandler(),
                MaxReceiveMessageSize = 1024,
                MaxSendMessageSize = 1024,
            });
        }
        public static async void GetInfoReactCommand()
        {
            using (var channel = GetChannel())
            {
                var client = new GrpcService.Protos.Test.TestClient(channel);
                var rez = await client.GetInfoAsync(new GrpcService.Protos.InfoReply { Id = _AddModelViewModel.UserId });
                var test = rez.Age; 
            }
        }

        public static async  void AddInfoReactCommand()
        {
            using (var channel = GetChannel())
            {
                var client = new GrpcService.Protos.Test.TestClient(channel);
                var rez = await client.InsertInfoAsync(new GrpcService.Protos.InfoReply { Id = _AddModelViewModel.UserId, Age = _AddModelViewModel.Age, Name = _AddModelViewModel.Username });
            }
            MessageBox.Show("Успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

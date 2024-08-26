using Grpc.Net.Client;
using ReactiveUI;
using System.ComponentModel;
using System.Net.Http;

namespace WpfApp.ViewModel
{
    internal abstract class ViewModelBase : ReactiveObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler? CanExecuteChanged;

        
        protected void OnProretryChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }

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
    }
}

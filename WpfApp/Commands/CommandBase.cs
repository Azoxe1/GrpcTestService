using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.Commands
{
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);
        protected void OnCanExcuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
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

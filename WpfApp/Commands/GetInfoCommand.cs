using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp.Commands
{
    class GetInfoCommand : CommandBase
    {
        private readonly AddModelViewModel _AddModelViewModel;
        public MainWindow mainWindow;


        public GetInfoCommand(AddModelViewModel _addModelViewModel)
        {
            _AddModelViewModel = _addModelViewModel;
            _AddModelViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddModelViewModel.UserId))
            {
                OnCanExcuteChanged(); 
            }
        }

        public async override void Execute (object parameter)
        {
            using (var channel = GetChannel())
            {
                var client = new GrpcService.Protos.Test.TestClient(channel);
                var rez = await client.GetInfoAsync(new GrpcService.Protos.InfoReply { Id = _AddModelViewModel.UserId });
                _AddModelViewModel.GetInfoText = rez.Age.ToString();
                //mainWindow = new MainWindow();
                //mainWindow.Content = rez.Age + " " + rez.Name;
                //mainWindow.Show();

            }
        }
    }
}

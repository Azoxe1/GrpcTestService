using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp.Commands
{
    internal class ChangeInModelCommand : CommandBase
    {
        private readonly AddModelViewModel _AddModelViewModel;

        public ChangeInModelCommand(AddModelViewModel makeSearchViewModel)
        {
            _AddModelViewModel = makeSearchViewModel;
        }

        public async override void Execute(object parameter)
        {
            using (var channel = GetChannel())
            {
                var client = new GrpcService.Protos.Test.TestClient(channel);
                var rez = await client.ChangeInfoAsync(new GrpcService.Protos.InfoReply { Id = _AddModelViewModel.UserId, Age = _AddModelViewModel.Age, Name = _AddModelViewModel.Username });
            }
            MessageBox.Show("Успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

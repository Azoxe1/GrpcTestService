using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp.Commands
{
    internal class DeleteFromModelCommand : CommandBase
    {
        private readonly AddModelViewModel _AddModelViewModel;

        public DeleteFromModelCommand(AddModelViewModel makeSearchViewModel)
        {
            _AddModelViewModel = makeSearchViewModel;
        }

        public async override void Execute(object parameter)
        {
            using (var channel = GetChannel())
            {
                var client = new GrpcService.Protos.Test.TestClient(channel);
                var rez = await client.DeleteInfoAsync(new GrpcService.Protos.InfoReply { Id = _AddModelViewModel.UserId});
            }
            MessageBox.Show("Успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

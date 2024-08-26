using System.Windows;
using WpfApp.ViewModel;

namespace WpfApp.Commands
{
    class AddInfoCommand : CommandBase
    {
        private readonly AddModelViewModel _AddModelViewModel;

        public AddInfoCommand(AddModelViewModel makeSearchViewModel)
        {
            _AddModelViewModel = makeSearchViewModel;
        }

        public async override void  Execute(object parameter)
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

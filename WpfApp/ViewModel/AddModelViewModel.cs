using System.Windows.Input;
using WpfApp.Commands;
using ReactiveUI;
using System.Reactive;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp.ViewModel
{
    internal class AddModelViewModel : ViewModelBase
    {
        //public ICommand GetInfoCommand { get; }
        //public ICommand AddToModelCommand { get; }
        //public ICommand DeleteFromModelCommand { get; }
        //public ICommand ChangeInModelCommand { get; }

        //public AddModelViewModel()
        //{
        //    AddToModelCommand = new AddInfoCommand(this);
        //    GetInfoCommand = new GetInfoCommand(this);
        //    DeleteFromModelCommand = new DeleteFromModelCommand(this);
        //    ChangeInModelCommand = new ChangeInModelCommand(this);
        //}

        private int _Userid;

        public int UserId
        {
            get
            {
                return _Userid;
            }
            set
            {
                _Userid = value;
                OnProretryChanged(nameof(UserId));
            }
        }
        private string _username;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnProretryChanged(nameof(Username));
            }
        }
        private int _Age;

        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
                OnProretryChanged(nameof(Age));
            }
        }

        private string _GetInfoText;

        public string GetInfoText
        {
            get
            {
                return _GetInfoText;
            }
            set
            {
                _GetInfoText = value;
                OnProretryChanged(nameof(GetInfoText));
            }
        }

       

        public AddModelViewModel()
        {
            GetInfoCommand = ReactiveCommand.Create(GetInfoReact);
            AddToModelCommand = ReactiveCommand.Create(AddInfoReact);
        }
        public ReactiveCommand<Unit, Unit> GetInfoCommand { get; }
        public ReactiveCommand<Unit, Unit> AddToModelCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteFromModelCommand { get; }
        public ReactiveCommand<Unit, Unit> ChangeInModelCommand { get; }

        private void GetInfoReact()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                ForReactiveCommands.GetInfoReactCommand();
            }));
        }

        private void AddInfoReact()
        {
                ForReactiveCommands.AddInfoReactCommand();
        }

    }
}

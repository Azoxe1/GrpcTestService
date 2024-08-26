using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.ViewModel
{
    internal class ShowDBViewModel : ViewModelBase
    {
        private readonly BaseModel _baseModel;

        public ShowDBViewModel(BaseModel baseModel)
        {
            _baseModel = baseModel;
        }

        public string ID => _baseModel.UserId.ToString();
        public string Name => _baseModel.Username;
        public string Age => _baseModel.Age.ToString();

    }
}

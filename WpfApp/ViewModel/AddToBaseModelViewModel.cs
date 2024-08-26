using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.ViewModel
{
    internal class AddToBaseModelViewModel /*для вывода на вьюхи*/
    {
        public  BaseModel _baseModel;

        public int UserId => _baseModel.UserId;
        public string Username => _baseModel.Username;
        public int Age => _baseModel.Age;

        public AddToBaseModelViewModel (BaseModel baseModel)
        {
            _baseModel = baseModel;
        }
    }
}

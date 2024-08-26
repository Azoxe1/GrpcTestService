using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    internal class BaseModel
    {
        public int UserId { get; }
        public string Username { get; }
        public int Age { get; }
        public BaseModel(int id, string name, int age)
        {
            UserId = id;
            Username = name;
            Age = age;
        }
    }
}

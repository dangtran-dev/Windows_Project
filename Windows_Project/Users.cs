using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project
{
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

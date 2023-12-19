using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ООО_СТОЛОВЫЕ_ПРИБОРЫ.Tools;

namespace ООО_СТОЛОВЫЕ_ПРИБОРЫ.ViewModel
{
    class LoginVM : BaseVM
    {
        private readonly PasswordBox pass;
        private CommandVM enter;

        public string Login { get; set; }
        public string Password { get; set; }

        public CommandVM Enter { get => enter; set { enter = value; Signal(); } }

        public LoginVM(PasswordBox pass)
        {
            this.pass = pass;
            Enter = new CommandVM(() => { }, () => true);
        }
    }
}

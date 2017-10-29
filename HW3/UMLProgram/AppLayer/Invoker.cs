using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class Invoker
    {
        private Command command;

        public void SetCommand(Command _command)
        {
            command = _command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}

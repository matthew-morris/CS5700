using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicUML
{
    public interface Command
    {
        void execute();
        void undo();
    }

    public class Invoker
    {
        Command myCommand;

        public void setCommand(Command tempCommand)
        {
            myCommand = tempCommand;
        }
    }
}

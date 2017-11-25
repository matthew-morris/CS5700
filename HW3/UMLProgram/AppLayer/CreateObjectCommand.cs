using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class CreateObjectCommand : Command
    {
        Object myObject;
        List<AppLayer.Object> myObjects;

        public CreateObjectCommand(Object _object, ref List<AppLayer.Object> _myObjects)
        {
            myObject = _object;
            myObjects = _myObjects;
        }

        public void execute()
        {
            myObjects.Add(myObject);
        }

        public void undo()
        {
            myObjects.Remove(myObject);
        }
    }
}

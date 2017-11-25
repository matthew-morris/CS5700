using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class DeleteObjectCommand : Command
    {
        Object myObject;
        List<Object> myObjects;

        public DeleteObjectCommand(Object _object, ref List<AppLayer.Object> _myObjects)
        {
            myObjects = _myObjects;
            myObject = _object;
        }
        public void execute()
        {
            myObjects.Remove(myObject);
        }
        public void undo()
        {
            myObjects.Add(myObject);
        }
    }
}

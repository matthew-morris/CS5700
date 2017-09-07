using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace MyClasses
{
    public class JSONReader : Reader
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<Person>));

        public override void Read(List<Person> list, string filename)
        {
            filename = AppendExtension(filename, "json");
            StreamReader reader = new StreamReader(filename);
            List<Person> data = JsonSerializer.ReadObject(reader.BaseStream) as List<Person>;
            if (data != null)
            {
                foreach (Person thing in data)
                    list.Add(thing);
            }
        }
    }
}

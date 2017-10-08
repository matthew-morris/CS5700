using System.Collections.Generic;
namespace MyClasses
{
    public abstract class Writer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract void Write(List<PairsOfPersons> list, string filename);

        protected string AppendExtension(string filename, string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                extension = string.Empty;

            if (string.IsNullOrWhiteSpace(filename))
                filename = string.Empty;

            if (!extension.StartsWith("."))
                extension = "." + extension;

            if (!filename.EndsWith(extension))
                filename += extension;

            return filename;
        }
    }
}

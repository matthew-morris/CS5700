using System;

using MyClasses;
using System.Diagnostics;

namespace PersonMatcher
{
    public class Program
    {
        private static readonly Reader[] Readers = new Reader[]
                {
                            new JSONReader() { Name = "JSON", Description  = "JavaScript Object Notation"},
                            new XMLReader() { Name = "XML", Description = "Extensible Markup Language"}
                };

        private static readonly Writer[] Writers = new Writer[]
                {
                            new ConsoleWriter() { Name = "CONSOLE", Description = "Output to console" },
                            new FileWriter() { Name = "TXT", Description  = "Text File"}
                };

        private static readonly Algorithm[] Algorithms = new Algorithm[]
                {
                            new Algorithm_NameTest() { Name = "1", Description = "Compare Persons by full name" },
                            new Algorithm_MotherTest() { Name = "2", Description = "Compare Persons by mother and birth information" },
                            new Algorithm_Identifiers() { Name = "3", Description = "Compare Persons by Social Security Number, State File Number, and Newborn Screening Number" }
                };

        static void Main(string[] args)
        {
            // Collect the data from test cases
            Reader reader = GetFileFormatFromUser();
            if (reader == null)
                return;

            string dataFileName = GetFilenameFromUser();
            if (string.IsNullOrWhiteSpace(dataFileName))
                return;

            PersonCollection collection = new PersonCollection() { myReader = reader, MyDataFile = dataFileName};
            try
            {
                collection.Read();
            }
            catch
            {
                Console.WriteLine("Error: Input file not found");
                EndProgram();
                return;
            }

            // Collect output file information
            Writer writer = GetOutputFileFormatFromUser();
            if (writer == null)
                return;

            string outputFileName = "";
            if (writer != Writers[0]) {
                outputFileName = GetOutputFilenameFromUser();
                if (string.IsNullOrWhiteSpace(outputFileName))
                    return;
            }

            PersonMatch personMatcher = new PersonMatch() { myWriter = writer, MyOutputFile = outputFileName, myPersonCollection = collection } ;

            //Run algorithm on unmatched pairs and create matched pairs
            personMatcher.CreateUnmatchedPairs();
            personMatcher.myPairs.myAlg = GetAlgorithmFromUser();

            personMatcher.RunTest();

            personMatcher.Write();
            Console.WriteLine("");

            EndProgram();
            return;
        }

        private static string GetOutputFilenameFromUser()
        {
            string result = null;
            Console.Write($"Enter output file name or EXIT? ");
            string response = Console.ReadLine()?.Trim();

            if (response != "EXIT")
                result = response;

            Console.WriteLine();

            return result;
        }

        private static Writer GetOutputFileFormatFromUser()
        {
            Writer result = null;
            while (result == null)
            {
                Console.WriteLine("Output File Types:");
                foreach (Writer thing in Writers)
                    Console.WriteLine($"\t{thing.Name.PadRight(10)}{thing.Description}");
                Console.Write("Specify which format type you want to write to? \nIf none are chosen, results will be written to the Console. ");
                string response = Console.ReadLine()?.Trim().ToUpper();

                if (response == "EXIT")
                    return null;

                foreach (Writer thing in Writers)
                {
                    if (response == thing.Name)
                    {

                        result = thing;
                        break;
                    }
                    else
                    {
                        result = Writers[0];
                    }
                }
            }
            Console.WriteLine();

            return result;
        }

        private static Reader GetFileFormatFromUser()
        {
            Reader result = null;
            while (result == null)
            {
                Console.WriteLine("File Format Types:");
                foreach (Reader thing in Readers)
                    Console.WriteLine($"\t{thing.Name.PadRight(10)}{thing.Description}");
                Console.Write("Specify which format type you want to read or EXIT? ");
                string response = Console.ReadLine()?.Trim().ToUpper();

                if (response == "EXIT")
                    return null;

                foreach (Reader thing in Readers)
                {
                    if (response == thing.Name)
                    {
                        result = thing;
                        break;
                    }
                }
            }
            Console.WriteLine();

            return result;
        }

        private static Algorithm GetAlgorithmFromUser()
        {
            Algorithm result = null;
            while (result == null)
            {
                Console.WriteLine("Algorithm options:");
                foreach (Algorithm thing in Algorithms)
                    Console.WriteLine($"\t{thing.Name.PadRight(10)}{thing.Description}");
                Console.Write("Specify which algorithm you want to use to match or EXIT? ");
                string response = Console.ReadLine()?.Trim().ToUpper();

                if (response == "EXIT")
                    return null;

                foreach (Algorithm thing in Algorithms)
                {
                    if (response == thing.Name)
                    {
                        result = thing;
                        break;
                    }
                }
            }
            Console.WriteLine();

            return result;
        }

        private static string GetFilenameFromUser()
        {
            string result = null;
            Console.Write($"Enter data file name or EXIT? ");
            string response = Console.ReadLine()?.Trim();

            if (response != "EXIT")
                result = response;

            Console.WriteLine();
            return result;
        }

        private static void EndProgram()
        {
            Console.WriteLine("Type ENTER to exit");
            Console.WriteLine("");
            Console.ReadLine();
            return;
        }
    }
}

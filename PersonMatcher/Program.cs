﻿using System;

using MyClasses;

namespace PersonMatcher
{
    public class Program
    {
        private const string DefaultDataFilename = "../../SampleData";

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

        static void Main(string[] args)
        {
            Reader reader = GetFileFormatFromUser();
            if (reader == null)
                return;

            string dataFileName = GetFilenameFromUser();
            if (string.IsNullOrWhiteSpace(dataFileName))
                return;

            Writer writer = GetOutputFileFormatFromUser();
            if (writer == null)
                return;

            string outputFileName = "";
            if (writer != Writers[0]) {
                outputFileName = GetOutputFilenameFromUser();
                if (string.IsNullOrWhiteSpace(outputFileName))
                    return;
            }
            

            // Collect the data from test cases
            PersonCollection data1 = new PersonCollection() { myReader = reader, myWriter = writer, MyDataFile = dataFileName, MyOutputFile = outputFileName };
            data1.Read();
            data1.Write();

            Console.WriteLine("Type ENTER to exit");
            Console.WriteLine("");
            Console.ReadLine();
        }

        private static string GetOutputFilenameFromUser()
        {
            string result = null;
            Console.Write($"Enter output file name or EXIT (default={DefaultDataFilename})? ");
            string response = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(response))
                response = DefaultDataFilename;

            if (response != "EXIT")
                result = response;

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
                Console.Write("Specify which format type you want to write to? \n f none are chosen, results will be written to the Console. ");
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

            return result;
        }

        private static string GetFilenameFromUser()
        {
            string result = null;
            Console.Write($"Enter data file name or EXIT (default={DefaultDataFilename})? ");
            string response = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(response))
                response = DefaultDataFilename;

            if (response != "EXIT")
                result = response;

            return result;
        }
    }
}

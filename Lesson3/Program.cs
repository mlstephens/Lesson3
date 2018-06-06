using Project.ConsoleApp.Parser;
using Project.Interface;
using Project.Xml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.ConsoleApp
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] clArguments)
        {
            if (clArguments.Any(a => String.Compare(a, "-xml", true) == 0))
            {
                IFileHandling ifhXml =  new XmlParser(clArguments);

                //create a list then order it so nulls are last in the list
                List<string> parsedData = ifhXml.GetParsedData(GetFilePath(clArguments, "-xml"))
                    .OrderBy(fh => fh)
                    .ToList()
                    .OrderBy(ai => ai == null)
                    .ToList();

                //display the list and replace nulls with No Value
                parsedData.ForEach(vi => Console.WriteLine("{0}", vi ?? "No Value"));
            }
            else
            {
                throw new ArgumentException("Invalid arguments.");
            }

            string GetFilePath(string[] arguments, string argumentNameValue)
            {
                string filePath = clArguments.SkipWhile(a => string.Compare(a, argumentNameValue, true) != 0)
                    .Skip(1)
                    .DefaultIfEmpty("")
                    .First()
                    .ToString();

                return filePath;
            }
        }
    }
}

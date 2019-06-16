using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sweety_Demo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
			string text = string.Empty;
			if (args.Length > 0)
            {
				string val = args[0];
				text = File.ReadAllText(val);
            }
            else
            {
                Console.Write("Enter the file path..");
				string val = Console.ReadLine();
				text = File.ReadAllText(val);
            }
            // Console.Write("Enter the file path..");
            // string val = Console.ReadLine();
            // string text = File.ReadAllText(val);
            var result = GetResult(text);
            Console.WriteLine(result);
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        public static string GetResult(string text)
        {
            List<string> combinedLines = new List<string>();
            string[] lines = text.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None
            );
            foreach (var line in lines)
            {
                string[] splitedLine = line.Split(' ');
                string surname = splitedLine[splitedLine.Length - 2];
                string givenNames = line.Substring(0,line.IndexOf(surname, StringComparison.Ordinal));
                var reversedLine = string.Concat(surname + " ", givenNames);
                combinedLines.Add(reversedLine + "," + line);
            }

            combinedLines.Sort();
            var result = combinedLines.Select(x => x.Split(',')[1]);
            return string.Join(Environment.NewLine, result.ToArray());
        }
    }
}

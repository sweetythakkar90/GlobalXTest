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
				//this will take the file name path. and read the text from the text file given
				string val = args[0];
				text = File.ReadAllText(val);
            }
            else
            {
                Console.Write("Enter the file path..");
				string val = Console.ReadLine();
				text = File.ReadAllText(val);
            }
         // GetResult() function is used to convert the names in the text file by ascending surname and return the result.
            var result = GetResult(text);
	//show the result
            Console.WriteLine(result);
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        public static string GetResult(string text)
        {
		//Initialise the combinedLines list which will be used to save the (surname_givenName, givenNames_Surname) values as a string
            List<string> combinedLines = new List<string>();
		// the argument text will be split to get the array of names 
            string[] lines = text.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None
            );
		//foreach loop to loop thru all the names 
            foreach (var line in lines)
            {
		    //split the line by space 
                string[] splitedLine = line.Split(' ');
		    //get the string of surname by splitting.
                string surname = splitedLine[splitedLine.Length - 2];
		    //get the given names
                string givenNames = line.Substring(0,line.IndexOf(surname, StringComparison.Ordinal));
		    //concat surname and given name so it can be sorted by surname ascending
                var reversedLine = string.Concat(surname + " ", givenNames);
		    //add the reverse surname-givenNames and givenNames-surname as a string by comma seperated so can be split again
		    //to return the result in the given names follwed by surname order 
                combinedLines.Add(reversedLine + "," + line);
            }
		//sort the list as it will start with surname
            combinedLines.Sort();
		//now split the list items by ","
            var result = combinedLines.Select(x => x.Split(',')[1]);
		//return the result as a string
            return string.Join(Environment.NewLine, result.ToArray());
        }
    }
}

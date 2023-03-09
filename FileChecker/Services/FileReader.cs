using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.API;

namespace Services
{
    public class FileReader : IFileReader
    {
        public FileReader()
        {   
        }

        /// <summary>
        /// > Reads a file line by line and returns the contents as a string
        /// </summary>
        public async Task<string> ReadFileLineByLine(string fileContents)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample-data", "weather.json");
            string GetFullPath = Path.GetFullPath(path);

            Console.WriteLine("Reading file line by line...");
            Console.WriteLine(GetFullPath);

            if (File.Exists(GetFullPath))
            {
                Console.WriteLine("File exists");
            }

            return string.Empty;
        }
    }
}
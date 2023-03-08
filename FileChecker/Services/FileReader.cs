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
        public string ReadFileLineByLine()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.FriendlyName, "test", "file.json");            

            Console.WriteLine("Reading file line by line...");
            Console.WriteLine(path);

            if (File.Exists(path))
            {
                Console.WriteLine("File exists");
            }

            return string.Empty;
        }
    }
}
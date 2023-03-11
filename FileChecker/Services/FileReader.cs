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
        public List<string> ReadFileLineByLine(string fileContents)
        {
            List<string> lines = new List<string>();

            using (StringReader reader = new StringReader(fileContents))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        public List<string> CompareFileLineByLine(List<string> fileContents, string reference)
        {
            List<string> lines = new List<string>();

            using (StringReader reader = new StringReader(reference))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!fileContents.Contains(line))
                    {
                        lines.Add(line);
                    }
                }
            }

            return lines;
        }
    }
}
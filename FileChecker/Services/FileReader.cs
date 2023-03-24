using Services.API;
using FileChecker.Models;

namespace Services
{
    public class FileReader : IFileReader
    {
        private Dictionary<string, List<int>> initialValues = new Dictionary<string, List<int>>();
        public FileReader()
        {   
        }

        /// <summary>
        /// > Reads a file line by line and returns the contents as a string
        /// </summary>
        public List<string>  ReadFileLineByLine(string fileContents)
        {
            List<string> lines = new List<string>();

            using (StringReader reader = new StringReader(fileContents))
            {
                int lineNumber = 1;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (initialValues.TryGetValue(line, out List<int> value))
                    {
                        value.Add(lineNumber);
                        initialValues[line] = value;
                    }
                    else
                    {
                        initialValues.Add(line, new List<int> { lineNumber });
                    }
                    lines.Add(line);
                    lineNumber++;
                }
            }

            return lines;
        }

        public (Dictionary<string, List<int>>, Dictionary<string, List<int>>) CompareFileLineByLine(List<string> fileContents, string reference, SpecialCharacters specialCharacters)
        {
            Dictionary<string, List<int>> uncontained = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> contained = new Dictionary<string, List<int>>();

            using (StringReader reader = new StringReader(reference))
            {
                string line;
                int i = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    // Skip special characters
                    if (specialCharacters.Chars.Contains(line.Trim())) continue;

                    if (initialValues.TryGetValue(line, out List<int> value))
                    {
                        value.Add(i + 1);
                        contained[line] = value;
                    }
                    else
                    {
                        uncontained.Add(line, new List<int> { i + 1 });
                    }
                    i++;
                }
            }

            return (contained, uncontained);
        }

        private static bool TryGetValue(List<string> fileContent ,string key, int index,out string value)
        {
            try
            {
                if (fileContent[index].Contains(key))
                {
                    value = key;
                    return true;
                }

                value = key;
                return false;
            }
            catch (System.Exception)
            {
                value = key;    
                return false;
            }
        }        
    }
}
using Services.API;

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

        public (List<string>, Dictionary<int, string>) CompareFileLineByLine(List<string> fileContents, string reference)
        {
            List<string> containedLines = new List<string>();
            Dictionary<int,string> uncontainedLines = new Dictionary<int, string>();

            using (StringReader reader = new StringReader(reference))
            {
                string line;
                int i = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (TryGetValue(fileContents, line, i, out string value))
                    {
                        containedLines.Add(value);
                    }
                    else
                    {
                        uncontainedLines.Add(i + 1,value);
                    }

                    i++;
                }
            }

            return (containedLines, uncontainedLines);
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
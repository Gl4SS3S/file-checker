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

        public (List<string>, List<string>) CompareFileLineByLine(List<string> fileContents, string reference)
        {
            List<string> containedLines = new List<string>();
            List<string> uncontainedLines = new List<string>();

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
                        uncontainedLines.Add(value);
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
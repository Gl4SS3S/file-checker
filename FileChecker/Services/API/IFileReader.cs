using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.API
{
    public interface IFileReader
    {
        /// <summary>
        /// > Reads a file line by line and returns the contents as a string
        /// </summary>
        List<string> ReadFileLineByLine(string fileContents);

        (List<string>, Dictionary<int, string>) CompareFileLineByLine(List<string> fileContents, string reference);
    }
}
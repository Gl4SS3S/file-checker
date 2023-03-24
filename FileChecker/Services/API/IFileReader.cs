using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileChecker.Models;

namespace Services.API
{
    public interface IFileReader
    {
        /// <summary>
        /// > Reads a file line by line and returns the contents as a string
        /// </summary>
        List<string>  ReadFileLineByLine(string fileContents);

        (Dictionary<string, List<int>>, Dictionary<string, List<int>>) CompareFileLineByLine(List<string> fileContents, string reference, SpecialCharacters specialCharacters);
    }
}
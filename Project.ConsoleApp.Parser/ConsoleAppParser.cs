﻿using Project.Interface;
using System.Linq;

namespace Project.ConsoleApp.Parser
{
    public class ConsoleAppParser : IFileHandling
    {
        public string[] ParseFileData(string filePath)
        {
            return !string.IsNullOrEmpty(filePath) ? new string[] { filePath } : System.Array.Empty<string>();
        }

        #region  ' IFileHandling '        

        public string[] GetParsedData(string filePath) => ParseFileData(filePath).ToArray();

        #endregion
    }
}

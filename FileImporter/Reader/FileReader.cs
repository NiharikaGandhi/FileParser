using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FileImporter.Reader
{
    public interface IFileReader
    {
        IEnumerable<string> GetFile(string filePath);
        string GetFileFormat(IEnumerable<string> fileContents);
        string[] GetFileContents(IEnumerable<string> fileContents);
    }
    public class FileReader : IFileReader
    {
        public IEnumerable<string> GetFile(string filePath)
        {
            try
            {
                return File.ReadLines(filePath);
            }
            catch (Exception ex)
            {
                //log
            }
            return new List<string>();
        }

        public string GetFileFormat(IEnumerable<string> fileContents)
        {
           return fileContents.FirstOrDefault();
        }

        public string[] GetFileContents(IEnumerable<string> fileContents)
        {
            if (fileContents.Count() > 1)
            {
                return fileContents.Skip(1).ToArray();
            }

            return null;
        }
    }
}
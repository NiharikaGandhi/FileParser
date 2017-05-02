using System.Collections.Generic;
using FileImporter.Models;

namespace FileImporter.Factory
{
    public interface IFileFactory
    {
        bool CanTransform(string fileFormat);
        IEnumerable<Book> Transform(string[] contents);
    }
}
using System.Collections.Generic;
using System.Linq;
using FileImporter.Factory;
using FileImporter.Models;
using FileImporter.Reader;

namespace FileImporter.Service
{
    public interface IFileService
    {
        IEnumerable<Book> Parse(string filePath);
    }

    public class FileService : IFileService
    {
        private readonly IFileReader _fileReader;
        private readonly IEnumerable<IFileFactory> _fileTransformer;
        
        public FileService(IFileReader fileReader, IEnumerable<IFileFactory> fileTransformer)
        {
            _fileReader = fileReader;
            _fileTransformer = fileTransformer;
        }

        public IEnumerable<Book> Parse(string filePath)
        {
            var file = _fileReader.GetFile(filePath);
            if (file.Any())
            {
                var fileFormat = _fileReader.GetFileFormat(file);
                var fileContents = _fileReader.GetFileContents(file);
                if (!(fileFormat != null & fileContents != null))
                {
                    return new List<Book>();
                }
                var transformer = _fileTransformer.FirstOrDefault(_ => _.CanTransform(fileFormat));
                var books = transformer?.Transform(fileContents);
                return books;
            }

            return new List<Book>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileImporter.Models;

namespace FileImporter.Data
{
    public interface IFileRepository
    {
        Task<bool> SaveBooks(List<Book> books);
        Task<List<Book>> GetBooks();
    }

    public class FileRepository : IFileRepository
    {
        public Task<bool> SaveBooks(List<Book> books)
        {
            return Task.FromResult(true);
        }

        public Task<List<Book>> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
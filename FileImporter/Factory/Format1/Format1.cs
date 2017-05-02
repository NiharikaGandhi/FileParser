using System;
using System.Collections.Generic;
using FileImporter.Models;

namespace FileImporter.Factory.Format1
{
    public class Format1 : IFileFactory
    {
        private readonly ISettings _settings;
        private readonly IStringExtensionMethods _stringExtensionMethods;

        public Format1(ISettings settings, IStringExtensionMethods stringExtensionMethods)
        {
            _settings = settings;
            _stringExtensionMethods = stringExtensionMethods;
        }

        public bool CanTransform(string fileFormat)
        {
            return fileFormat == "A";
        }

        public IEnumerable<Book> Transform(string[] contents)
        {
            var books = new List<Book>();
            foreach (var contentwithtab in contents)
            {
                try
                {
                    var content = _stringExtensionMethods.RemoveTab(contentwithtab);
                    var book = new Book
                    {
                        Name = _stringExtensionMethods.GetString(content,0 , _settings.NameEndsAt),
                        ISBN = _stringExtensionMethods.GetString(content, _settings.NameEndsAt, _settings.IsbnEndsAt),
                        Author = _stringExtensionMethods.GetString(content, _settings.IsbnEndsAt, _settings.AuthorEndsAt)
                    };
                    books.Add(book);
                }
                catch (IndexOutOfRangeException ex)
                {
                    //log error
                    continue;
                }
                catch (Exception ex)
                {
                    //log error
                    continue;
                }
            }

            return books;
        }
    }
}
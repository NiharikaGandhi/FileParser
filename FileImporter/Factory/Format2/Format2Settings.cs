namespace FileImporter.Factory.Format2
{
    public class Format2Settings : ISettings
    {
        public int NameEndsAt => 30; // can be added to configuration file
        public int IsbnEndsAt => 51;
        public int AuthorEndsAt => 72;
    }
}
namespace FileImporter.Factory.Format1
{
    public class Format1Settings : ISettings
    {
        public int NameEndsAt => 20;
        public int IsbnEndsAt => 41;
        public int AuthorEndsAt => 62;
    }
}
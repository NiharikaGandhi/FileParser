namespace FileImporter.Factory
{
    public interface ISettings
    {
        int NameEndsAt { get; }
        int IsbnEndsAt { get;  }
        int AuthorEndsAt { get;  }
    }
}
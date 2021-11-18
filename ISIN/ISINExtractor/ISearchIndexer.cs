namespace ISINExtractor
{
    public interface ISearchIndexer
    {
        string IndexDocument(string documentJson);
    }
}
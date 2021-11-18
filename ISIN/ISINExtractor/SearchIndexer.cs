namespace ISINExtractor
{
    using System.IO;
    using System.Text.Json;

    public class SearchIndexer : ISearchIndexer
    {
        private string csvFileName = "output.csv";
        
        private class IsinIndexItem
        {
            public string Figi { get; set; }
            public string Isin { get; set; }
            public string CompanyName { get; set; }
        }
        public string IndexDocument(string documentJson)
        {
            var document = JsonSerializer.Deserialize<IsinIndexItem>(documentJson);
            
            using (StreamWriter sw = File.AppendText(this.csvFileName))
            {
                sw.WriteLine(document.Figi + "," + document.Isin + "," + document.CompanyName);
            }
            
            return "OK";
        }
    }
}
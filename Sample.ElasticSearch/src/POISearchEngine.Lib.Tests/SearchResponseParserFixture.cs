using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace POISearchEngine.Lib.Tests
{
    public class SearchResponseParserFixture
    {
        [Fact]
        public void Parser_Should_Parse_Search_Response_Correctly()
        {
            
            ESConnection conn = new ESConnection();
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"), "poi_index");
            ESIndexer indexer = new ESIndexer();
            ESSearcher searcher = new ESSearcher();
            SearchResponseParser parser = new SearchResponseParser();
            indexer.CreateIndex(client,
                new POI()
                {
                    Name = "Sambar",
                    Type = "Restaurant",
                    Description = "A Good Place"
                });
            var response = indexer.GetResponse();
            var searchResponse = searcher.Search(client, "Sambar");
            var result = parser.Parse(searchResponse).Distinct();
            Assert.NotNull(result);
        }
    }
}

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
            string index = "poi_ind";
            string type = "poi";
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"), index);
            ESIndexer indexer = new ESIndexer(client, index, type);
            var response = indexer.CreateIndex(new POI()
            {
                Id="1",
                Name = "Sambar1",
                Type = "Restaurant",
                Description = "A Good Place"
            });

            var response2 = indexer.CreateIndex(new POI()
            {
                Id = "2",
                Name = "Sambar2",
                Type = "Restaurant",
                Description = "A Great Place"
            });
            ESSearcher searcher = new ESSearcher(client, index, type);
            var searchResponse = searcher.Search("Restaurant");
            SearchResponseParser parser = new SearchResponseParser();
            var result = parser.Parse(searchResponse);
            Assert.NotNull(result);
        }
    }
}

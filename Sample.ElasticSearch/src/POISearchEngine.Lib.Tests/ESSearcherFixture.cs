using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Nest;

namespace POISearchEngine.Lib.Tests
{
    public class ESSearcherFixture
    {
        [Fact]
        public void Search_Should_Return_Valid_Result()
        {            
            ESSearcher searcher = new ESSearcher();
            ESConnection conn = new ESConnection();
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"), "poi_index");
            ESIndexer indexer = new ESIndexer();
            indexer.CreateIndex(client,
                new POI()
                {
                    Name = "Sambar",
                    Type = "Restaurant",
                    Description = "A Good Place"
                });
            var response = indexer.GetResponse();
            var result=searcher.Search(client,"Sambar");
            Assert.NotNull(result);
        }
    }
}

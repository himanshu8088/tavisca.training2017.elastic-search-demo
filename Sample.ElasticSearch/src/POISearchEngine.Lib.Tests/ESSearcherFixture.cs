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
            ESConnection conn = new ESConnection();
            string index = "poi_ind";
            string type = "poi";
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"), index);
            ESIndexer indexer = new ESIndexer(client, index, type);
            var response = indexer.CreateIndex(new POI()
            {
                Name = "Sambar",
                Type = "Restaurant",
                Description = "A Good Place"
            });

            ESSearcher searcher=new ESSearcher(client, index, type);
            var result=searcher.SearchByType("Sambar");
            Assert.NotNull(result);
        }
    }
}

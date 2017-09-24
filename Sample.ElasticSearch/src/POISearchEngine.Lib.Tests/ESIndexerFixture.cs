using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Xunit;

namespace POISearchEngine.Lib.Tests
{
    public class ESIndexerFixture
    {
        [Fact]
        public void GetIndex_Should_Return_Response_When_ESCLient_Available()
        {
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
            Assert.NotNull(response);
        }
    }
}

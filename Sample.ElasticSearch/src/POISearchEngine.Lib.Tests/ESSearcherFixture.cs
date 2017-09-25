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
        private ESConnection _conn;
        private string _index;
        private string _type;
        private ElasticClient _client;
        private ESIndexer _indexer;        

        public void Initialise()
        {            
            _conn = new ESConnection();
            _index = "poi_ind";
            _type = "poi";
            _client = _conn.GetClient(new Uri("http://172.16.14.115:9200/"), _index);
            _indexer = new ESIndexer(_client, _index, _type);
            var response = _indexer.CreateIndex(new POI()
            {
                Id="1",
                Name = "Sambar",
                Type = "Restaurant",
                Description = "A Good Place"
            });
        }

        [Fact]
        public void SearchByType_Should_Return_Valid_Result()
        {
            //Arrange
            Initialise();
            ESSearcher searcher=new ESSearcher(_client, _index, _type);
            //Act            
            var response=searcher.SearchByType("Sambar");
            //Assert
            Assert.NotNull(response);
        }

        [Fact]
        public void Search_Should_Return_Valid_Result()
        {
            Initialise();
            ESSearcher searcher = new ESSearcher(_client, _index, _type);              
            ISearchResponse<POI> response = searcher.Search("Restaurant");
            Assert.NotNull(response);
        }
    }
}

using System;
using Xunit;
using Nest;

namespace ESSearchEngine.Lib.Tests
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
            _index = "test";
            _type = "test_entry";
            _client = _conn.GetClient(new Uri("http://172.16.14.115:9200/"), _index);
            _indexer = new ESIndexer(_client, _index, _type);
            var response = _indexer.CreateIndex<object>(new { test_field = "test value" }, "1");
        }
        
        [Fact]
        public void Search_Should_Return_Valid_Result()
        {
            Initialise();
            ESSearcher<object> searcher = new ESSearcher<object>(_client, _index, _type);              
            ISearchResponse<object> response = searcher.Search("test value");
            Assert.NotNull(response);
        }

        //[Fact]
        //public void SearchByType_Should_Return_Valid_Result()
        //{
        //    //Arrange
        //    Initialise();
        //    ESSearcher<Log> searcher=new ESSearcher<Log>(_client, _index, _type);
        //    //Act            
        //    var response=searcher.SearchByType("Sambar");
        //    //Assert
        //    Assert.NotNull(response);
        //}
    }
}

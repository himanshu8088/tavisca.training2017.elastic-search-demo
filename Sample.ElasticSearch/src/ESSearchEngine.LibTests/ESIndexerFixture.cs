using System;
using Xunit;

namespace ESSearchEngine.Lib.Tests
{
    public class ESIndexerFixture
    {
        [Fact]
        public void GetIndex_Should_Return_Response_When_ESCLient_Available()
        {
            ESConnection conn = new ESConnection();
            string index = "test";
            string type = "test_entry";
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"), index);
            ESIndexer indexer = new ESIndexer(client,index,type);            
            var response = indexer.CreateIndex<object>(new { test_field="test value" }, "2");                                
            Assert.NotNull(response);
        }

        [Fact]
        public void Delete_Should_Return_Valid_Response_When_Deleted()
        {
            ESConnection conn = new ESConnection();
            string index = "test";
            string type = "test_entry";
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"), index);
            ESIndexer indexer = new ESIndexer(client, index, type);
            var response=indexer.DeleteIndex(client, index);
            Assert.NotNull(response);
        }
    }
}

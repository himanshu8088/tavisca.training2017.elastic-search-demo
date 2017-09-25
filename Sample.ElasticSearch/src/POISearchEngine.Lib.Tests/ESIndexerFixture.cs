﻿using System;
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
            string index = "poi_ind";
            string type = "poi";
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"), index);
            ESIndexer indexer = new ESIndexer(client,index,type);
            var response=indexer.CreateIndex(new POI()
                                {
                                    Id="1",
                                    Name = "Sambar",
                                    Type = "Restaurant",
                                    Description = "A Good Place"
                                });                        
            Assert.NotNull(response);
        }

        [Fact]
        public void Delete_Should_Return_Valid_Response_When_Deleted()
        {
            ESConnection conn = new ESConnection();
            string index = "poi_ind";
            string type = "poi";
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"), index);
            ESIndexer indexer = new ESIndexer(client, index, type);
            var response=indexer.DeleteIndex(client, index);
            Assert.NotNull(response);
        }
    }
}

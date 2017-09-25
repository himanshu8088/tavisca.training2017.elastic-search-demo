using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Nest;

namespace POISearchEngine.Lib.Tests
{
    public class ESConnectionFixture
    {
        [Fact]
        public void GetClient_Should_Return_Elastic_Client_When_All_Parameters_Are_Set()
        {
            ESConnection conn = new ESConnection();
            var client = conn.GetClient(new Uri("http://172.16.14.115:9200/"));
            Assert.NotNull(client);
        }        
    }
}

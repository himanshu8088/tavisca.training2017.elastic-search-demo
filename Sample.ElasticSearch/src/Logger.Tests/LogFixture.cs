using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Logger;

namespace Logger.Tests
{
    public class LogFixture
    {
        [Fact]
        public void Store_Should_Not_Return_Exception()
        {
            Log log = new Log(new Uri("http://172.16.14.115:9200/"),1);          
            log.Store("rq_param", "rs_param", "test_passed");            
        }

        [Fact]
        public void Store_Should_Return_Exception()
        {
            Log log = new Log(new Uri("http://172.16.14.115:9201/"),1);            
            Assert.Throws<Exception>(() => log.Store("rq_param", "rs_param", "test_passed"));            
        }
    }
}

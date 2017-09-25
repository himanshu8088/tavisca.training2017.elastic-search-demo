using Nest;
using System;

namespace POISearchEngine.Lib
{
    public class ESConnection
    {
        public ElasticClient GetClient(Uri node,string index=null)
        {                      
            index = index ?? "test";
            var settings = new ConnectionSettings(node).DefaultIndex(index);            
            var client = new ElasticClient(settings);                       
            return client;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace POISearchEngine.Lib
{
    public class ESIndexer
    {        
        private ElasticClient _client;
        private string _index;
        private string _type;
        public ESIndexer(ElasticClient client, string index, string type)
        {
            _client = client;
            _index = index;
            _type = type;
        }

        public IIndexResponse CreateIndex(POI poi)
        {            
            var response = _client.Index(poi, i => i
                          .Index(_index)
                          .Type(_type)
                          .Id(poi.Id)
                          );
            return response;
        }

        public IDeleteIndexResponse DeleteIndex(ElasticClient client, string index)
        {
            var response = client.DeleteIndex(index);
            return response;
        }
        
    }
}

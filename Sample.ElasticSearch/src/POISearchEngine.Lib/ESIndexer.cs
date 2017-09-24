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
        private IIndexResponse _indexResponse;
        
        public void CreateIndex(ElasticClient client,POI poi)
        {
            _indexResponse = client.Index(poi);
        }

        public IIndexResponse GetResponse()
        {            
            return _indexResponse;
        }
    }
}

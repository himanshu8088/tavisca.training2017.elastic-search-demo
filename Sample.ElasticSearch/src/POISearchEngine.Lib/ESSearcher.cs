using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace POISearchEngine.Lib
{
    public class ESSearcher
    {
        private ElasticClient _client;
        private string _index;
        private string _type;
        public ESSearcher(ElasticClient client, string index, string type)
        {
            _client = client;
            _index = index;
            _type = type;
        }
        public ISearchResponse<POI> Search(string searchText)
        {            
            var searchResponse = _client.Search<POI>(s => s
                                .Index(_index)
                                .Type(_type)
                                .Query(q => q
                                     .Match(m => m                                        
                                        .Query(searchText)
                                        .Field(f=>f.Type)
                                     )
                                )
                               );
            return searchResponse;
        }
    }
}

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
        public ISearchResponse<POI> Search(ElasticClient client, string searchText)
        {
            var searchResponse = client.Search<POI>(s => s
                                .AllTypes()
                                .From(0)
                                .Size(10)
                                .Query(q => q
                                     .Match(m => m                                        
                                        .Query(searchText)
                                     )
                                )
                               );
            return searchResponse;
        }
    }
}

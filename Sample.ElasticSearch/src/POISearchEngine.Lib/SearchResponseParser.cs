using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace POISearchEngine.Lib
{
    public class SearchResponseParser
    {
        public List<POI> Parse(ISearchResponse<POI> response)
        {
            var results = response.Hits.Distinct();
            List<POI> poiList = new List<POI>();

            foreach(var result in results)
            {
                poiList.Add(result.Source);
            }
            return poiList;
        }
    }
}

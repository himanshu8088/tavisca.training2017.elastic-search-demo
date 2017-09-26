using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace ESSearchEngine.Lib
{
    public class ESSearcher<T> where T:class
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
        //public ISearchResponse<T> SearchByType(string searchText, T type)
        //{
        //    var searchResponse = _client.Search<T>(s => s
        //                        .Index(_index)
        //                        .Type(_type)
        //                        .Query(q => q
        //                             .Match(m => m
        //                                .Query(searchText)
        //                                .Field(f => f.)
        //                             )
        //                        )
        //                       );
        //    return searchResponse;
        //}

        public ISearchResponse<T> Search(string text)
        {
            var searchResponse = _client.Search<T>(s => s
                                                           .Index(_index)
                                                           .Type(_type)
                                                           .Query(q => q
                                                                        .QueryString(qStr => qStr
                                                                                                 .Query(text)
                                                                                    )
                                                                 )
                                                   );
            return searchResponse;                     
        }
    }
}

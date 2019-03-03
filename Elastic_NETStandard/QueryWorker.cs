using System;
using System.Collections.Generic;
using System.Text;
using Elasticsearch.Net;

namespace Elastic_NETStandard
{
    public class QueryWorker
    {
        public string QueryLowLevel(string query)
        {
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200")).RequestTimeout(TimeSpan.FromMinutes(2));
            var lowlevelClient = new ElasticLowLevelClient(settings);

            //var searchResponse = lowlevelClient.Search<StringResponse>("outlook", "doc", PostData.Serializable(new
            //{
            //    from = 0,
            //    size = 10,
            //    query = new
            //    {
            //        match = new
            //        {
            //            field = "body",
            //            query = "youtube"
            //        }
            //    }
            //}));

            var searchResponse = lowlevelClient.Search<BytesResponse>("outlook", "doc", @"
            {
                ""query"": {
                    ""match"": {
                        ""body"": """ + query + @"""
                    }
                }
            }");


            var successful = searchResponse.Success;
            var responseJson = searchResponse.Body;

            return System.Text.Encoding.Default.GetString(responseJson);
        }
    }
}

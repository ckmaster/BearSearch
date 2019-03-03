using System;
//using Nest;
//using Elasticsearch;
using Elasticsearch.Net;

namespace Elastic_NETStandard
{
    public class Indexer
    {
        //public void IndexHighLevel(JObject jObject)
        //{
        //    ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("gutenberg").DisableDirectStreaming();
        //    ElasticClient client = new ElasticClient(settings);
        //    IIndexResponse indexResponse = client.IndexDocument(jObject);
        //    CommonComponents_NETStandard.Globals.logger.CreateOrAppend(indexResponse.DebugInformation);
        //}

        public void IndexLowLevel(string jsonBody)
        {
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200")).RequestTimeout(TimeSpan.FromMinutes(2));
            var lowlevelClient = new ElasticLowLevelClient(settings);
            var indexResponse = lowlevelClient.Index<BytesResponse>("outlook", "doc", PostData.String(jsonBody));
            byte[] responseBytes = indexResponse.Body;
            CommonComponents_NETStandard.Globals.logger.CreateOrAppend(responseBytes.ToString());
        }
    }
}

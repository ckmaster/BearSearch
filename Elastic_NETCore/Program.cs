using System;
using Nest;
using Elasticsearch;
using Elasticsearch.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elastic_NETCore
{
    public class Program
    {
        public void IndexHighLevel (JObject jObject)
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("gutenberg").DisableDirectStreaming();
            ElasticClient client = new ElasticClient(settings);
            IIndexResponse indexResponse = client.IndexDocument(jObject);
            CommonComponents_NETStandard.Globals.logger.CreateOrAppend(indexResponse.DebugInformation);
        }

        public void IndexLowLevel (string jsonBody)
        {
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200")).RequestTimeout(TimeSpan.FromMinutes(2));
            var lowlevelClient = new ElasticLowLevelClient(settings);
            var indexResponse = lowlevelClient.Index<BytesResponse>("gutenberg", "doc", PostData.String(jsonBody));
            byte[] responseBytes = indexResponse.Body;
            CommonComponents_NETStandard.Globals.logger.CreateOrAppend(responseBytes.ToString());
        }
    }
}

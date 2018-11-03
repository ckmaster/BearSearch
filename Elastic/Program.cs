using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Elasticsearch;
using Elasticsearch.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elastic
{
    public class Program
    {
        public void IndexHighLevel(JObject jObject)
        {
            ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("gutenberg").DisableDirectStreaming();
            ElasticClient client = new ElasticClient(settings);
            IIndexResponse indexResponse = client.IndexDocument(jObject);
            CommonComponents.Globals.logger.CreateOrAppend(indexResponse.DebugInformation);
        }

        public void IndexLowLevel (string jsonBody)
        {
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200")).RequestTimeout(TimeSpan.FromMinutes(2));
            var lowlevelClient = new ElasticLowLevelClient(settings);
            var indexResponse = lowlevelClient.Index<BytesResponse>("gutenberg", "doc", PostData.String(jsonBody));
            byte[] responseBytes = indexResponse.Body;
            CommonComponents.Globals.logger.CreateOrAppend(responseBytes.ToString());
        }
    }
}

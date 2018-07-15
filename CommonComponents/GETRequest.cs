using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace CommonComponents
{
    public class GetRequest : WebShared
    {
        public GetRequest(string baseUrl, string urlParameters, string body, Dictionary<string, string> headers): base(baseUrl, urlParameters, body, headers)
        {
            WebShared.method = "GET";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents_NETStandard
{
    public class GetRequest : WebShared
    {
        public GetRequest (string baseUrl, string urlParameters, string body, Dictionary<string, string> headers) : base(baseUrl, urlParameters, body, headers)
        {
            WebShared.method = "GET";
        }
    }
}

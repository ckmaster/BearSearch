using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents_NETCore
{
    public class PutRequest : WebShared
    {
        public PutRequest (string baseUrl, string urlParameters, string body, Dictionary<string, string> headers) : base(baseUrl, urlParameters, body, headers)
        {
            WebShared.method = "PUT";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents_NETStandard
{
    public class DeleteRequest : WebShared
    {
        public DeleteRequest (string baseUrl, string urlParameters, string body, Dictionary<string, string> headers) : base(baseUrl, urlParameters, body, headers)
        {
            WebShared.method = "DELETE";
        }
    }
}

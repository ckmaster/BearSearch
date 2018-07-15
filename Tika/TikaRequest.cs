using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonComponents;

//Detect Stream - PUT Returns the expect content type (use the filename hint)
//Meta - PUT return metadata in response body
//Tika - PUT Return text in response body
//remeta - recursive metadata, all embedded documents
//unpack - return unpacked text with original filenames
//Almost all the above methods support POST with multi-part form (useful for large files)

namespace Tika
{
    public class TikaRequest
    {
        private string baseUrl = "http://localhost:9998/";
        private string urlParameters;

        public TikaRequest() {}

        public string GetDetectors()
        {
            urlParameters = "/detectors";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");
            GETRequest getRequest = new GETRequest(baseUrl, urlParameters, "", headers);
            string responseBody = getRequest.GetResponseBody();
            return responseBody;
        }

        public string 

        
    }
}

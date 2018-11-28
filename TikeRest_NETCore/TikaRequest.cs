using System;
using System.Collections.Generic;
using System.Text;
using CommonComponents_NETStandard;
using System.IO;

namespace TikeRest_NETCore
{
    public class TikaRequest
    {
        private string baseUrl = "http://localhost:9998";
        public TikaRequest () { }

        public string GetDetectors ()
        {
            string urlParameters = "/detectors";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");
            GetRequest getRequest = new GetRequest(baseUrl, urlParameters, "", headers);
            string responseBody = getRequest.GetResponseBody();
            return responseBody;
        }

        public string DetectStream (string filePath)
        {
            string urlParameters = "/detect/stream";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            string fileName = Path.GetFileName(filePath);
            headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            PutRequest putRequest = new PutRequest(baseUrl, urlParameters, filePath, headers);
            string responseBody = putRequest.GetResponseBody();
            return responseBody;
        }

        public string Meta (string filePath)
        {
            string urlParameters = "/meta";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");
            string fileName = Path.GetFileName(filePath);
            PutRequest putRequest = new PutRequest(baseUrl, urlParameters, filePath, headers);
            string responseBody = putRequest.GetResponseBody();
            return responseBody;
        }

        public string TikaXML (string filePath)
        {
            string urlParameters = "/tika";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "text/xml");
            string fileName = Path.GetFileName(filePath);
            PutRequest putRequest = new PutRequest(baseUrl, urlParameters, filePath, headers);
            string responseBody = putRequest.GetResponseBody();
            return responseBody;
        }

        public string TikaPlain (string filePath)
        {
            string urlParameters = "/tika";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Accept", "text/plain");
            string fileName = Path.GetFileName(filePath);
            PutRequest putRequest = new PutRequest(baseUrl, urlParameters, filePath, headers);
            string responseBody = putRequest.GetResponseBody();
            return responseBody;
        }
    }
}

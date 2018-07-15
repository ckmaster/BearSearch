﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.IO;

namespace CommonComponents
{
    public abstract class WebShared
    {
        protected static string baseUrl;
        protected static string urlParameters;
        protected static string body;
        protected static Dictionary<string, string> headers;
        protected static string method;

        public WebShared(string baseUrl, string urlParameters, string body, Dictionary<string, string> headers)
        {
            WebShared.baseUrl = baseUrl;
            WebShared.urlParameters = urlParameters;
            WebShared.body = body;
            WebShared.headers = headers;
        }

        static HttpWebRequest BuildRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{baseUrl}{urlParameters}");
            request.Method = method;
            foreach (KeyValuePair<string, string> header in headers)
            {
                if (!WebHeaderCollection.IsRestricted(header.Key))
                {
                    request.Headers.Add(header.Key, header.Value);
                }
                else
                {
                    System.Reflection.PropertyInfo prop = typeof(HttpWebRequest).GetProperty(header.Key);
                    //object value = prop.GetValue(request);
                    prop.SetValue(request, header.Value);
                }
            }
            return request;
        }

        public static HttpWebResponse ExecuteRequest()
        {
            HttpWebRequest request = BuildRequest();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }

        public string GetResponseBody(HttpWebResponse response)
        {
            string responseBody = "";
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                responseBody = reader.ReadToEnd();
            }
            return responseBody;
        }

        public string GetResponseBody()
        {
            HttpWebResponse response = ExecuteRequest();
            string responseBody = "";
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                responseBody = reader.ReadToEnd();
            }
            return responseBody;
        }
    }
}
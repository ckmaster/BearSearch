using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace CommonComponents
{
    public class XmlToJson
    {
        private static bool xmlFail;
        private static string xml;

        public XmlToJson(string xml)
        {
            XmlToJson.xml = xml;
        }

        public string Convert()
        {
            XmlDocument doc = new XmlDocument();
            xmlFail = true;
            string json = "";

            while (xmlFail)
            {
                try
                {
                    doc.LoadXml(xml);
                    xmlFail = false;
                }
                catch (XmlException xe)
                {
                    xmlFail = true;
                    xml = HandleOtherChars(xe, xml);
                }
            }
            //The test files from Gutenberg project currently return \r\r\n as new line chracters.  See how these index, and decide if that data should be modified.
            json = JsonConvert.SerializeXmlNode(doc);
            return json;
        }

        private static string HandleOtherChars(XmlException xe, string responseBody)
        {
            string badChar = xe.Message.Substring(0, xe.Message.IndexOf(" "));
            badChar = badChar.Replace("'", "");
            badChar = badChar.Replace(",", "");
            string newString = responseBody.Replace(badChar, "");
            return newString;
        }
    }
}

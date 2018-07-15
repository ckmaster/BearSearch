using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tika;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            TikaRequest tikaRequest = new TikaRequest();
            FileDiscovery fileDiscovey = new FileDiscovery();
            string[] files = fileDiscovey.FindFiles(@"C:\TestFiles");
            foreach (string file in files)
            {
                string xmlResponse = tikaRequest.TikaXML(file);
                CommonComponents.XmlToJson xmlToJson = new CommonComponents.XmlToJson(xmlResponse);
                string jsonResponse = xmlToJson.Convert();
                CommonComponents.Globals.logger.CreateOrAppend(jsonResponse);
                //CommonComponents.Globals.logger.CreateOrAppend((tikaRequest.TikaXML(file) + "\n"));
            }
        }
    }
}

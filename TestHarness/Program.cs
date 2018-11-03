using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikaRest;
using CommonComponents;
using Elastic;

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
                XmlToJson xmlToJson = new XmlToJson(xmlResponse);
                string jsonResponse = xmlToJson.Convert();
                //Globals.logger.CreateOrAppend(jsonResponse);
                JsonManager jsonManager = new JsonManager(jsonResponse);
                //Globals.logger.CreateOrAppend((tikaRequest.TikaXML(file) + "\n"));
                Elastic.Program elasticProgram = new Elastic.Program();
                //elasticProgram.IndexHighLevel(jsonManager.GenericDeserialize());
                elasticProgram.IndexLowLevel(jsonResponse);
            }
        }
    }
}

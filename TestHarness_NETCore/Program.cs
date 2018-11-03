using System;
using TikeRest_NETCore;
using CommonComponents_NETCore;
using Elastic_NETCore;

namespace TestHarness_NETCore
{
    class Program
    {
        static void Main (string[] args)
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
                Elastic_NETCore.Program elasticProgram = new Elastic_NETCore.Program();
                //elasticProgram.IndexHighLevel(jsonManager.GenericDeserialize());
                elasticProgram.IndexLowLevel(jsonResponse);
            }
        }
    }
}

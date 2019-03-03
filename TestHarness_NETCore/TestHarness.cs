using System;
using TikeRest_NETCore;
using CommonComponents_NETStandard;

namespace TestHarness_NETCore
{
    class TestHarness
    {
        static void Main (string[] args)
        {
            TikaRequest tikaRequest = new TikaRequest();
            FileCrawler_NETCore.FileCrawler fileDiscovey = new FileCrawler_NETCore.FileCrawler();
            string[] files = fileDiscovey.FindFiles(@"C:\TestFiles");
            foreach (string file in files)
            {
                string xmlResponse = tikaRequest.TikaXML(file);
                XmlToJson xmlToJson = new XmlToJson(xmlResponse);
                string jsonResponse = xmlToJson.Convert();
                //Globals.logger.CreateOrAppend(jsonResponse);
                JsonManager jsonManager = new JsonManager();
                //Globals.logger.CreateOrAppend((tikaRequest.TikaXML(file) + "\n"));
                Elastic_NETCore.Elastic elasticProgram = new Elastic_NETCore.Elastic();
                //elasticProgram.IndexHighLevel(jsonManager.GenericDeserialize());
                elasticProgram.IndexLowLevel(jsonResponse);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OutlookCrawler_NetFramework;
using Elasticsearch;
using Elasticsearch.Net;

namespace OutlookCrawler_NETFramework
{
    public class OutlookCrawler
    {
        static void Main(string[] args)
        {
            Application app = null;
            _NameSpace ns = null;
            MailItem item = null;
            MAPIFolder inboxFolder = null;
            MAPIFolder subFolder = null;

            try
            {
                app = new Application();
                ns = app.GetNamespace("MAPI");
                ns.Logon(null, null, false, false);
                inboxFolder = ns.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
                subFolder = inboxFolder.Folders["TEST"];
                Console.WriteLine("Folder Name: {0}, EntryId: {1}", subFolder.Name, subFolder.EntryID);
                Console.WriteLine("Num Items: {0}", subFolder.Items.Count.ToString());
                for (int i=1; i<=subFolder.Items.Count;i++)
                {
                    item = (MailItem)subFolder.Items[i];
                    Message message = new Message(item);
                    string json = JsonConvert.SerializeObject(message);
                    IndexLowLevel(json);
                }
                //item = ns.GetItemFromID("000000006F8917C81DA08C409D3B1B49454F46C90700C6936CD0FB24CA4482A4BEEF45C1DF1E0000000002100000C6936CD0FB24CA4482A4BEEF45C1DF1E000000001C020000");
                //item.Display();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
            finally
            {
                ns = null;
                app = null;
                inboxFolder = null;
            }
        }

        private static void IndexLowLevel(string jsonBody)
        {
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200")).RequestTimeout(TimeSpan.FromMinutes(2));
            var lowlevelClient = new ElasticLowLevelClient(settings);
            var indexResponse = lowlevelClient.Index<BytesResponse>("outlook", "doc", PostData.String(jsonBody));
            byte[] responseBytes = indexResponse.Body;
            CommonComponents_NETStandard.Globals.logger.CreateOrAppend(responseBytes.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace OutlookCrawler_NETFramework
{
    class Program
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
                    //Console.WriteLine("Item: {0}", i.ToString());
                    //Console.WriteLine("Subject: {0}", item.Subject);
                    //Console.WriteLine("Sent: {0} {1}", item.SentOn.ToLongDateString(), item.SentOn.ToLongTimeString());
                    //Console.WriteLine("Categories: {0}", item.Categories);
                    CommonComponents_NETStandard.Logger logger = new CommonComponents_NETStandard.Logger($"{i}.log");
                    logger.CreateOrAppend(item.Body);
                    CommonComponents_NETStandard.Logger htmlLogger = new CommonComponents_NETStandard.Logger($"{i}_html.log");
                    htmlLogger.CreateOrAppend(item.HTMLBody);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                ns = null;
                app = null;
                inboxFolder = null;
            }
        }
    }
}

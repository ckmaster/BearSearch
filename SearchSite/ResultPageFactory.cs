using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Outlook;
using Newtonsoft.Json.Linq;

namespace SearchSite
{
    public class ResultPageFactory
    {
        public System.Web.UI.WebControls.Table TableBuilder(string json)
        {
            System.Web.UI.WebControls.Table tempTable = new System.Web.UI.WebControls.Table();
            CommonComponents_NETStandard.JsonManager jsonManager = new CommonComponents_NETStandard.JsonManager();
            JObject jObject = jsonManager.GenericDeserialize(json);
            List<string> subjects = jsonManager.GetMultiTokenValues(jObject, "$...subject");
            List<string> itemIds = jsonManager.GetMultiTokenValues(jObject, "$...entryID");
            for (int i = 0; i < subjects.Count; i++)
            {
                TableRow tempRow = new TableRow();
                TableCell subjectCell = new TableCell
                {
                    Text = subjects[i]
                };
                tempRow.Cells.Add(subjectCell);

                TableCell itemIdCell = new TableCell
                {
                    Text = itemIds[i]

                };
                tempRow.Cells.Add(itemIdCell);

                TableCell buttonCell = new TableCell();
                Button button = new Button
                {
                    Text = "Click me",
                    ToolTip = itemIds[i]
                };
                button.Click += (s, ev) => { OpenMessage((s as Button).ToolTip); };
                buttonCell.Controls.Add(button);
                tempRow.Cells.Add(buttonCell);

                tempTable.Rows.Add(tempRow);
            }
            return tempTable;
        }

        protected void OpenMessage(string itemId)
        {
            Application app = null;
            _NameSpace ns = null;
            MailItem item = null;

            app = new Application();
            ns = app.GetNamespace("MAPI");
            ns.Logon(null, null, false, false);
            item = ns.GetItemFromID(itemId);
            item.Display();
        }
    }
}
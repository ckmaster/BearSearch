using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchSite
{
    public partial class ResultsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["QueryString"];
            Elastic_NETStandard.QueryWorker queryWorker = new Elastic_NETStandard.QueryWorker();
            string json = queryWorker.QueryLowLevel(queryString);
            ResultPageFactory resultPageFactory = new ResultPageFactory();
            Table table = resultPageFactory.TableBuilder(json);
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            content.Controls.Add(table);
        }
    }
}
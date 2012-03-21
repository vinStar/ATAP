using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsPDFHelpers;

public partial class Processed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["sLogs"] != null)
        {

            List<ClientLogger> LogList = new List<ClientLogger>();
            LogList = (List<ClientLogger>)(Session["sLogs"]);
            gvProcessed.DataSource = LogList;
            gvProcessed.DataBind();

        }


    }
}
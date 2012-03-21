using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsPDFHelpers;

public partial class Sessions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["sLogs"] != null)
        {

            

            
            List<ClientLogger> LogList = new List<ClientLogger>();
            LogList = (List<ClientLogger>)(Session["sLogs"]);
            GridView1.DataSource = LogList;
            GridView1.DataBind();

        }

    }
}
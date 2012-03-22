using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsPDFHelpers;

public partial class Processed : System.Web.UI.Page
{
    public string sTmpFolderPath = System.Web.HttpContext.Current.Server.MapPath(".\\Temp\\");

    protected void Page_Load(object sender, EventArgs e)
    {

    

     

        if (Session["sLogs"] != null)
        {

            System.IO.DirectoryInfo g = new System.IO.DirectoryInfo(sTmpFolderPath + Session["sDir"].ToString());
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(g.FullName);
            gvVolPDF.DataSource = dir.GetFiles("*.*");
            gvVolPDF.DataBind();


            List<ClientLogger> LogList = new List<ClientLogger>();
            LogList = (List<ClientLogger>)(Session["sLogs"]);
            gvProcessed.DataSource = LogList;
            gvProcessed.DataBind();

        }


    }
}
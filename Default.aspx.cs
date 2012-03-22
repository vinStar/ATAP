using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExpertPdf.HtmlToPdf;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using nsPDFHelpers;

public partial class _Default : System.Web.UI.Page
{

    public int iVolMax = 100;
    public string sTmpFolderPath = System.Web.HttpContext.Current.Server.MapPath(".\\Temp\\");

    protected void Page_Load(object sender, EventArgs e)
    {
      


        if (!IsPostBack)
        {
            InitalLoad();
        }

    }

    protected void InitalLoad()
    {


        Session.Remove("sLogs");
        Session.Abandon();
        Session.Clear();
    
        BaseMethods oGet = new BaseMethods();
        gvDocsToPDF.DataSource = oGet.GetJobs();
        gvDocsToPDF.DataBind();
        BindGrid();

        ltLocalDir.Text = sTmpFolderPath;
        ltFolderDir.Text = oGet.GenerateRandomFolderName();
        oGet = null;

    }



    protected void btnGetPDFs_Click(object sender, EventArgs e)
    {
        if (IsPostBack){

            string sDir = "";
            string sTemp;

            List<ClientLogger> LogList = new List<ClientLogger>();


            BaseMethods sFldr = new BaseMethods();
            sDir = sFldr.GenerateRandomFolderName();
            DirectoryInfo di = Directory.CreateDirectory(sTmpFolderPath + sDir);
            sTemp = sTmpFolderPath + sDir + "\\" ;


            foreach (GridViewRow rw in gvDocsToPDF.Rows)
            {
                if (rw.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbPDF = new CheckBox();
                    cbPDF = (CheckBox)(rw.FindControl("cbSelect"));

                    if (cbPDF.Checked)
                    {

                        string sVolume, sSection, sFileName, sFileURL;
                        sVolume = rw.Cells[1].Text.ToString();
                        sSection = rw.Cells[2].Text.ToString();
                        sFileName = rw.Cells[3].Text.ToString();
                        sFileURL = rw.Cells[4].Text.ToString();

                        DirectoryInfo oCreate = Directory.CreateDirectory(sTemp + sVolume);

                        BaseMethods oJob = new BaseMethods();
                        LogList.Add(oJob.GetPDFfromURLPDF(sFileURL, sTemp, sFileName, sVolume, sSection));
                        oJob = null;

                    }

                }
            }

            Session["sLogs"] = LogList;
            Session["sDir"] = sDir;

            BaseMethods oJobr = new BaseMethods(); 

            foreach (System.IO.DirectoryInfo g in di.GetDirectories())
            {

                List<ClientLogger> PDFList = new List<ClientLogger>();

                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(g.FullName);
                foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
                {

                    ClientLogger pdfLt = new ClientLogger(){
                        _sFile = f.Name, 
                        _sPath = f.DirectoryName,
                    };

                    PDFList.Add(pdfLt);
                   
                }

                oJobr.GetSinglePDFfromManyPDFs(PDFList, g.FullName, "_Vol.pdf");


            } 

            Response.Redirect("Processed.aspx");
            

           

        }
    }


    protected void cbSelect_CheckedChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void BindGrid()
    {
        int iTotalPDFpages = 0;
        int iPageCounter = 0;
        int iVolCounter = 0;
        int iSecCounter = 0;

        foreach (GridViewRow rw in gvDocsToPDF.Rows)
        {
            if (rw.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbPDF = new CheckBox();
                cbPDF = (CheckBox)(rw.FindControl("cbSelect"));

                if (cbPDF.Checked)
                {

                    int iCurrent = Int32.Parse(rw.Cells[6].Text.ToString());
                    iPageCounter += iCurrent;

                    iTotalPDFpages += Int32.Parse(rw.Cells[6].Text.ToString());

                    if (iVolCounter == 0 && iCurrent > iVolMax)
                    {
                        iPageCounter = 0;
                        iVolCounter += 1;
                        rw.Cells[1].Text = iVolCounter.ToString();
                        iVolCounter += 1;

                        iSecCounter = 1;
                        rw.Cells[2].Text = iSecCounter.ToString();
              
                    }
                    else if (iVolCounter == 0 && iCurrent <= iVolMax)
                    {
                        iVolCounter += 1;
                        rw.Cells[1].Text = iVolCounter.ToString();

                        iSecCounter += 1;
                        rw.Cells[2].Text = iSecCounter.ToString();
                        
                    }
                    else
                    {
                        if (iCurrent > iVolMax)
                        {

                            iPageCounter = iCurrent;
                            iVolCounter += 1;
                            rw.Cells[1].Text = iVolCounter.ToString();
                            iSecCounter = 1;
                            rw.Cells[2].Text = iSecCounter.ToString();

                        }
                        else if (iPageCounter > iVolMax)
                        {
                            iPageCounter = iCurrent;
                            iVolCounter += 1;
                            rw.Cells[1].Text = iVolCounter.ToString();
                            iSecCounter = 1;
                            rw.Cells[2].Text = iSecCounter.ToString();
                        }
                        else
                        {

                            rw.Cells[1].Text = iVolCounter.ToString();
                            iSecCounter += 1;
                            rw.Cells[2].Text = iSecCounter.ToString();
                          
                            
                        }
                    }





                }
                else
                {
                    rw.Cells[1].Text = "---";
                    rw.Cells[2].Text = "---";
                }



            }
           
           
        }
        ltTotalPgs.Text = iTotalPDFpages.ToString();
    }

}
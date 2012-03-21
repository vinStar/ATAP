using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class Pdf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string[] files = { @"C:\Inetpub\ATAP\Files\AD.pdf", @"C:\Inetpub\ATAP\Files\SC-100.pdf" };
             gvFiles.DataSource = files;
             gvFiles.DataBind();


        }


    }





    protected void btn_Click(object sender, EventArgs e)
    {

        string[] files = { @"C:\Inetpub\ATAP\Files\AD.pdf", @"C:\Inetpub\ATAP\Files\SC-100.pdf" };

        //PdfReader reader = new PdfReader(@"C:\Inetpub\ATAP\Files\Adopt-200.pdf");
        //PdfReader reader = new PdfReader(@"C:\Inetpub\ATAP\Files\FW-001.pdf");


        Document document = new Document(PageSize.A4, 10, 10, 10, 10);

        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"C:\Inetpub\ATAP\Files\New.pdf", FileMode.Create));

        document.Open();


        PdfImportedPage page;


        foreach (var file in files)
        {


            PdfReader reader = new PdfReader(file.ToString());
           

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                page = writer.GetImportedPage(reader, i);
                document.Add(iTextSharp.text.Image.GetInstance(page));
            }


            

        }

        document.Close();


        Label1.Text= "donde!";

        // ...and start a viewer.
    }
}
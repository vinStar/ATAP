using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;

public partial class Pdf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

      


    }
    protected void btn_Click(object sender, EventArgs e)
    {
       
        string[] files = { "C:\\Inetpub\\ATAP\\Files\\Adopt-200.pdf", "C:\\Inetpub\\ATAP\\Files\\SC-100.pdf" };

        // Open the output document
        PdfDocument outputDocument = new PdfDocument();

        // Iterate files
        foreach (string file in files)
        {
            // Open the document to import pages from it.
            PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.ReadOnly);

            // Iterate pages
            int count = inputDocument.PageCount;
            for (int idx = 0; idx < count; idx++)
            {
                // Get the page from the external document...
                PdfPage page = inputDocument.Pages[idx];
                // ...and add it to the output document.
                outputDocument.AddPage(page);
            }
        }

        // Save the document...
        const string filename = "C:\\Inetpub\\ATAP\\Files\\ConcatenatedDocument1_tempfile.pdf";
        outputDocument.Save(filename);
        // ...and start a viewer.
    }
}
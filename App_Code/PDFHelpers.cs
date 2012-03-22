using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpertPdf.HtmlToPdf;
using ExpertPdf.MergePdf;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;


namespace nsPDFHelpers{

    public class FilesToGrab
    {

        public string _sFileName { get; set; }
        public string _sFileURL { get; set; }
        public int _iJobOrder { get; set; }
        public int _iPages { get; set; }
        

    }

    public class ClientLogger
    {

        public string _sStart { get; set; }
        public string _sEnd { get; set; }
        public string _sSpan { get; set; }

        public string _sFile { get; set; }
        public string _sPath { get; set; }

        public string _Volume { get; set; }
        public string _Section { get; set; }
    }
        

    public class BaseMethods
    {

        public BaseMethods(){
            
        }

        public List<FilesToGrab> GetForms()
        {
            List<FilesToGrab> oList = new List<FilesToGrab>();

            FilesToGrab oAdd1 = new FilesToGrab() { _iPages = 26, _sFileName = "Adopt-200.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/Adopt-200.pdf" };
            oList.Add(oAdd1);

            FilesToGrab oAdd2 = new FilesToGrab() { _iPages = 6, _sFileName = "ADR.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/ADR.pdf" };
            oList.Add(oAdd2);

            FilesToGrab oAdd3 = new FilesToGrab() { _iPages = 14, _sFileName = "CR-180.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/CR-180.pdf" };
            oList.Add(oAdd3);

            FilesToGrab oAdd4 = new FilesToGrab() { _iPages = 68, _sFileName = "DV-100.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/DV-100.pdf" };
            oList.Add(oAdd4);

            FilesToGrab oAdd5 = new FilesToGrab() { _iPages = 12, _sFileName = "FW-001.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/FW-001.pdf" };
            oList.Add(oAdd5);

            FilesToGrab oAdd6 = new FilesToGrab() { _iPages = 22, _sFileName = "SC-100.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/SC-100.pdf" };
            oList.Add(oAdd6);

            FilesToGrab oAdd7 = new FilesToGrab() { _iPages = 42, _sFileName = "WV-100.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/WV-100.pdf" };
            //FilesToGrab oAdd8 = new FilesToGrab() { _iPages = 30, _sFileName = "UD-100.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/UD-100.pdf" };
            FilesToGrab oAdd9 = new FilesToGrab() { _iPages = 48, _sFileName = "CH-150.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/CH-150.pdf" };
            FilesToGrab oAdd10 = new FilesToGrab() { _iPages = 58, _sFileName = "FL-800.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/FL-800.pdf" };

            oList.Add(oAdd7);
            //oList.Add(oAdd8);
            oList.Add(oAdd9);
            oList.Add(oAdd10);
            return oList;
        }

        public List<FilesToGrab> GetJobs()
        {

            List<FilesToGrab> oListofJobs = new List<FilesToGrab>();



            FilesToGrab oAdd5 = new FilesToGrab() {  _iPages = 22, _iJobOrder = 0, _sFileName = "CRHC4985120211100829.pdf", _sFileURL = "http://dms/Criminal/2005/CRHC4985120211100829.pdf" };
            oListofJobs.Add(oAdd5);
            oAdd5 = null;

            FilesToGrab oAdd4 = new FilesToGrab() { _iPages = 12, _iJobOrder = 0, _sFileName = "CRHC4974120211100654.pdf", _sFileURL = "http://dms/Criminal/2005/CRHC4974120211100654.pdf" };
            oListofJobs.Add(oAdd4);
            oAdd4 = null;


            FilesToGrab oAdd3 = new FilesToGrab() { _iPages = 91, _iJobOrder = 2, _sFileName = "CRHC4975120211100656.pdf", _sFileURL = "http://dms/Criminal/2005/CRHC4975120211100656.pdf" };
            oListofJobs.Add(oAdd3);
            oAdd3 = null;

            FilesToGrab oAdd1 = new FilesToGrab() { _iPages = 8, _iJobOrder = 0, _sFileName = "CRCR1355121410120242.pdf", _sFileURL = "http://dms/Criminal/1968/CR-Confidential-1968/CRCR1355121410120242.pdf" };
            oListofJobs.Add(oAdd1);
            oAdd1 = null;

            FilesToGrab oAdd2 = new FilesToGrab() { _iPages = 64, _iJobOrder = 1, _sFileName = "CRMHC12011212092243.pdf", _sFileURL = "http://dms/Criminal/1980/CRMHC12011212092243.pdf" };
            oListofJobs.Add(oAdd2);
            oAdd2 = null;
          
            FilesToGrab oAdd8 = new FilesToGrab() { _iPages = 33, _iJobOrder = 1, _sFileName = "CRHC5639121611091133.pdf", _sFileURL = "http://dms/Criminal/2007/CRHC5639121611091133.pdf" };
            oListofJobs.Add(oAdd8);
            oAdd8 = null;

            FilesToGrab oAdd9 = new FilesToGrab() { _iPages = 89, _iJobOrder = 1, _sFileName = "CRHC5579121511042441.pdf", _sFileURL = "http://dms/Criminal/2007/CRHC5579121511042441.pdf" };
            oListofJobs.Add(oAdd9);
            oAdd9 = null;


            return oListofJobs;
        }

        public string GenerateRandomFolderName()
        {
           return Regex.Replace(DateTime.Now.TimeOfDay.ToString(), @"[^\w@-]", "");
        }

        public string GetTimeStamp()
        {
            return DateTime.Now.TimeOfDay.ToString();
        }

        public ClientLogger GetPDFfromURLPDF(string sURL, string sPath, string sFileName, string sVolume, string sSection)
        {

            ClientLogger oLog = new ClientLogger();
            using (WebClient client = new WebClient())
            {

                var sw = Stopwatch.StartNew();
                // business logic
                

                oLog._sFile = sFileName;
                oLog._sStart = GetTimeStamp();
                oLog._Section = sSection;
                oLog._Volume = sVolume;
                oLog._sPath = sPath + sVolume + "\\" + sFileName;
                client.Credentials = new System.Net.NetworkCredential("echavez","chavez9909", "COURTS");
                client.DownloadFile(sURL, oLog._sPath);
                
                while (client.IsBusy)
                {
                    System.Threading.Thread.Sleep(1000);
                }


                sw.Stop();
                TimeSpan time = sw.Elapsed;
                oLog._sSpan = time.ToString();
            }
            
            oLog._sEnd = GetTimeStamp();
           


            return oLog;
        }

        public void GetSinglePDFfromManyPDFs(List<ClientLogger> list, string sPath, string sFileName)
        {


            /////////////////////////////////////////////
            // itextsharp
            /////////////////////////////////////////////

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            iTextSharp.text.Font title = new iTextSharp.text.Font(bfTimes, 15, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
            iTextSharp.text.Font header = new iTextSharp.text.Font(bfTimes, 30, iTextSharp.text.Font.BOLD, BaseColor.BLUE);

            Document document = new Document(PageSize.A4, 10, 10, 10, 10);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(sPath + sFileName, FileMode.Create));
            document.Open();

            PdfImportedPage page;

            document.Add(new Paragraph("ATAP Project", header));
            document.Add(new Paragraph("Files in Volume", title));
            document.Add(new Chunk("\n"));

            int totalpages = 1;

            foreach (var ls in list)
            {
                Paragraph p4 = new Paragraph();
                p4.Add(new Chunk(ls._sFile).SetLocalGoto(ls._sFile));
                document.Add(p4);

                PdfReader rder = new PdfReader(sPath + "\\" + ls._sFile);
                document.Add(new Chunk("Pages: " + rder.NumberOfPages.ToString()));

                totalpages += rder.NumberOfPages;

                document.Add(new Chunk("\n\n"));
            }

            document.Add(new Chunk("Total Pages in Volume: " + totalpages.ToString()));

            document.NewPage();

            foreach (var ls in list)
            {

                PdfReader reader = new PdfReader(sPath + "\\" + ls._sFile);

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {

                    if (i == 1)
                    {
                        Paragraph p5 = new Paragraph();
                        p5.Add(new Chunk("-").SetLocalDestination(ls._sFile));
                        document.Add(p5);
                    }

                    page = writer.GetImportedPage(reader, i);
                    document.Add(iTextSharp.text.Image.GetInstance(page));

                   
                }

                page = writer.GetImportedPage(reader, 1);
                int pg = page.PageNumber;
                document.Add(new Chunk(pg.ToString()));
            }

      
           
            document.Close();


            /////////////////////////////////////////////
            // EXPERT PDF
            /////////////////////////////////////////////

            //ExpertPdf.MergePdf.PdfDocumentOptions pdfDocumentOptions = new ExpertPdf.MergePdf.PdfDocumentOptions();
            //pdfDocumentOptions.PdfCompressionLevel = ExpertPdf.MergePdf.PDFCompressionLevel.Normal;
            //ExpertPdf.MergePdf.PDFMerge pdfMerge = new ExpertPdf.MergePdf.PDFMerge(pdfDocumentOptions);

            //foreach (var item in list)
            //{
            //    pdfMerge.AppendPDFFile(sPath + item._sFile);
            //}
            //pdfMerge.AppendEmptyPage();
            //pdfMerge.SaveMergedPDFToFile(sPath + sFileName);


        }
	
}

}
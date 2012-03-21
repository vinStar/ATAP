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
    }
        

    public class BaseMethods
    {

        public BaseMethods(){
            
        }

        public List<FilesToGrab> GetForms()
        {
            List<FilesToGrab> oList = new List<FilesToGrab>();

            FilesToGrab oAdd1 = new FilesToGrab(){ _iPages = 26, _sFileName="Adopt-200.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/Adopt-200.pdf" };
            oList.Add(oAdd1);

            FilesToGrab oAdd2 = new FilesToGrab(){ _iPages = 6, _sFileName ="ADR.pdf", _sFileURL="http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/ADR.pdf" };
            oList.Add(oAdd2);

            FilesToGrab oAdd3 = new FilesToGrab(){ _iPages =14, _sFileName = "CR-180.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/CR-180.pdf" };
            oList.Add(oAdd3);

            FilesToGrab oAdd4 = new FilesToGrab() { _iPages = 68, _sFileName = "DV-100.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/DV-100.pdf" };
            oList.Add(oAdd4);

            FilesToGrab oAdd5 = new FilesToGrab() { _iPages = 12, _sFileName = "FW-001.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/FW-001.pdf" };
            oList.Add(oAdd5);

            FilesToGrab oAdd6 = new FilesToGrab() { _iPages = 22, _sFileName = "SC-100.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/SC-100.pdf" };
            oList.Add(oAdd6);

            FilesToGrab oAdd7 = new FilesToGrab() { _iPages = 42, _sFileName = "WV-100.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/WV-100.pdf" };
            FilesToGrab oAdd8 = new FilesToGrab() { _iPages = 30, _sFileName = "UD-100.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/UD-100.pdf" };
            FilesToGrab oAdd9 = new FilesToGrab() { _iPages = 48, _sFileName = "CH-150.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/CH-150.pdf" };
            FilesToGrab oAdd10 = new FilesToGrab() { _iPages = 58, _sFileName = "FL-800.pdf", _sFileURL = "http://www.monterey.courts.ca.gov/Documents/Forms/Court%20Packets/FL-800.pdf" };

            oList.Add(oAdd7);
            oList.Add(oAdd8);
            oList.Add(oAdd9);
            oList.Add(oAdd10);
            return oList;
        }

        public List<FilesToGrab> GetJobs()
        {

            List<FilesToGrab> oListofJobs = new List<FilesToGrab>();



            FilesToGrab oAdd5 = new FilesToGrab() { _iJobOrder = 0, _sFileName = "CRHC4985120211100829.pdf", _sFileURL = "http://dms/Criminal/2005/CRHC4985120211100829.pdf" };
            oListofJobs.Add(oAdd5);
            oAdd5 = null;

            FilesToGrab oAdd4 = new FilesToGrab() { _iJobOrder = 0, _sFileName = "CRHC4974120211100654.pdf", _sFileURL = "http://dms/Criminal/2005/CRHC4974120211100654.pdf" };
            oListofJobs.Add(oAdd4);
            oAdd4 = null;

            FilesToGrab oAdd1 = new FilesToGrab() { _iJobOrder = 0, _sFileName = "CRCR1355121410120242.pdf", _sFileURL = "http://dms/Criminal/1968/CR-Confidential-1968/CRCR1355121410120242.pdf" };
            oListofJobs.Add(oAdd1);
            oAdd1 = null;

            FilesToGrab oAdd2 = new FilesToGrab() { _iJobOrder = 1, _sFileName = "CRMHC12011212092243.pdf", _sFileURL = "http://dms/Criminal/1980/CRMHC12011212092243.pdf" };
            oListofJobs.Add(oAdd2);
            oAdd2 = null;

            FilesToGrab oAdd3 = new FilesToGrab() { _iJobOrder = 2, _sFileName = "CRHC4975120211100656.pdf", _sFileURL = "http://dms/Criminal/2005/CRHC4975120211100656.pdf" };
            oListofJobs.Add(oAdd3);
            oAdd3 = null;

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

        public ClientLogger GetPDFfromURLPDF(string sURL, string sPath, string sFileName)
        {

            ClientLogger oLog = new ClientLogger();
            using (WebClient client = new WebClient())
            {

                var sw = Stopwatch.StartNew();
                // business logic
                

                oLog._sFile = sFileName;
                oLog._sStart = GetTimeStamp();
                client.Credentials = new System.Net.NetworkCredential("echavez","chavez9909", "COURTS");
                client.DownloadFile(sURL, sPath + sFileName);
                
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


            string[] files = { @"C:\Inetpub\ATAP\Files\AD.pdf", @"C:\Inetpub\ATAP\Files\SC-100.pdf" };



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
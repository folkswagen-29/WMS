using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace onlineLegalWF
{
    public class MargePDF
    {
        public byte[] margePDF(MemoryStream[] listpdf)
        {

            MemoryStream[] streams = listpdf;
            byte[] bytes = null;
            using (MemoryStream finalStream = new MemoryStream())
            {
                //Create our copy object
                PdfCopyFields copy = new PdfCopyFields(finalStream);
                //var copy = new PdfCopy(document, finalStream);
                //copy.SetMergeFields();
                //document.Open();

                //Loop through each MemoryStream
                foreach (MemoryStream ms in streams)
                {
                    //Reset the position back to zero
                    ms.Position = 0;
                    //Add it to the copy object
                    copy.AddDocument(new PdfReader(ms));
                    //Clean up
                    ms.Dispose();
                }
                //Close the copy object
                copy.Close();

                //Get the raw bytes to save to disk
                bytes = finalStream.ToArray();
            }
            return bytes;
        }

        public string mergefilePDF(string[] listfiles, string output_directory) 
        {
            string resfile = "";
            Document doc = new Document();
            //string basePath = @"D:\Users\worawut.m\Downloads\";
            string basePath = output_directory;
            string outputfn = basePath + @"\mergePdf_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";
            PdfCopy copy = new PdfCopy(doc, new FileStream(outputfn, FileMode.Create));
            doc.Open();
            //string[] pdfFiles = { @"C__WordTemplate_Insurance_Output_inreq_20240114_204952.pdf", @"C__WordTemplate_Insurance_Output_inreq_20240112_165348.pdf" };
            string[] pdfFiles = listfiles;
            foreach (string filename in pdfFiles)
            {
                PdfReader reader = new PdfReader(filename);
                copy.AddDocument(reader);
                reader.Close();
            }
            doc.Close();
            resfile = outputfn;
            //System.Diagnostics.Process.Start(outputfn);

            return resfile;
        }
    }
}
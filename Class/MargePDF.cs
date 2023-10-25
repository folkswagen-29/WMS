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
    }
}
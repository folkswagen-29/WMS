using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReplaceDocx.Class
{
    public class ReplaceDocxResult 
    {
        public DocxData Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

    }
    public class DocxData
    {
        string worddoc_nodeid { get; set; }
        string worddoc_name { get; set; }
        byte[] worddoc_content { get; set; }
        string pdf_nodeid { get; set; }
        string pdf_name { get; set; }
        byte[] pdf_content { get; set; }
    }
}
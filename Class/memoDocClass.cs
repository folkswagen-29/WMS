using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
//using SelectPdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace onlineLegalWF
{
    public class memoDocClass
    {

        public class MyFontFactoryImpl : FontFactoryImp
        {
            Font defaultFont;
            public MyFontFactoryImpl()
            {

                BaseFont tahoma = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\tahoma.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                defaultFont = new Font(tahoma, 12);

            }
            public override Font GetFont(string fontname, string encoding, Boolean embedded, float size, int style, BaseColor color, Boolean cached)
            {
                return defaultFont;
            }
        }

        public class HtmlToPdf
        {
            string _html;
            public HtmlToPdf(string html)
            {
                if (!(FontFactory.FontImp is MyFontFactoryImpl))
                    FontFactory.FontImp = new MyFontFactoryImpl();
                _html = html;
            }



            public void Render(Stream stream)
            {
                StringReader sr = new StringReader(_html);
                Document pdfDoc = new Document();
                PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
            }

            public void Render(HttpResponse response, string fileName)
            {
                response.Clear();
                response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
                response.ContentType = "application/octet-stream";

                Render(response.OutputStream);

                response.End();
            }
        }

        public Font getFont(string _h1_bold_smallbold_normal_smallnormal)
        {

            BaseFont bf_bold = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~//fonts//THSarabunNew Bold.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var h = new Font(bf_bold, 22);
            var h1 = new Font(bf_bold, 18, Font.UNDERLINE);
            var bold = new Font(bf_bold, 16);
            var smallBold = new Font(bf_bold, 14);

            // Normal
            BaseFont bf_normal = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~//fonts//THSarabunNew.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var normal = new Font(bf_normal, 16);
            var smallNormal = new Font(bf_normal, 14);
            var normal_blue = new Font(bf_normal, 14, Font.NORMAL, BaseColor.BLUE);

            Font xfont = normal;
            switch (_h1_bold_smallbold_normal_smallnormal)
            {
                case "h": xfont = h; break;
                case "h1": xfont = h1; break;
                case "bold": xfont = bold; break;
                case "smallbold": xfont = smallBold; break;
                case "normal": xfont = normal; break;
                case "smallnormal": xfont = smallNormal; break;
                case "normal_blue": xfont = normal_blue; break;
            }
            return xfont;
        }
        private Document createPDFDocSize(string _A3A4, bool _landscape, HttpResponse Response)
        {
            Document pdfDoc = new Document();
            if (_A3A4 == "A4")
            {
                if (_landscape == false)
                {
                    pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                }
                else
                {
                    pdfDoc = new Document(PageSize.A4.Rotate(), 30, 30, 20, 20);
                }
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();

            }
            else if (_A3A4 == "A3")
            {
                if (_landscape == false)
                {
                    pdfDoc = new Document(PageSize.A3, 30, 30, 20, 20);
                }
                else
                {
                    pdfDoc = new Document(PageSize.A3.Rotate(), 30, 30, 20, 20);
                }
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
            }
            return pdfDoc;
        }
        private PdfPCell EmptyCell()
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            return new PdfPCell(new Phrase(new Chunk("", normal)));
        }
        private PdfPTable GetHeader(string xHeader, string xTitle)
        {

            PdfPTable headerTable = new PdfPTable(2);
            headerTable.TotalWidth = 530f;
            headerTable.HorizontalAlignment = 0;
            headerTable.SpacingAfter = 20;
            //headerTable.DefaultCell.Border = Rectangle.NO_BORDER;

            float[] headerTableColWidth = new float[2];
            headerTableColWidth[0] = 150f;
            headerTableColWidth[1] = 310f;

            headerTable.SetWidths(headerTableColWidth);
            headerTable.LockedWidth = true;

            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("../../images/LogoOnly.jpg"));
            png.ScaleAbsolute(40, 40);

            PdfPCell headerTableCell_0 = new PdfPCell(png);
            headerTableCell_0.HorizontalAlignment = Element.ALIGN_LEFT;
            headerTableCell_0.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCell_0);

            var h = getFont("h");
            var h1 = getFont("h1");

            PdfPCell headerTableCell = new PdfPCell(new Phrase(xHeader, h));
            //headerTableCell.HorizontalAlignment = Element.ALIGN_LEFT;
            headerTableCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            headerTableCell.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCell);

            PdfPCell headerTableCellEm = new PdfPCell(new Phrase("", h));
            //headerTableCell.HorizontalAlignment = Element.ALIGN_LEFT;
            headerTableCellEm.VerticalAlignment = Element.ALIGN_BOTTOM;
            headerTableCellEm.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCellEm);

            Phrase p = new Phrase();
            p.Add(new Chunk("                          "));
            p.Add(new Chunk(xTitle, h1));
            PdfPCell headerTableCell_1 = new PdfPCell(p);
            headerTableCell_1.HorizontalAlignment = Element.ALIGN_LEFT;
            headerTableCell_1.VerticalAlignment = Element.ALIGN_BOTTOM;
            headerTableCell_1.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCell_1);

            return headerTable;
        }
        private PdfPTable GetHeaderDetail(string xFormNo, string xCreateDate, string xDocNo, string xFrPosition, string xFrom, string xTo, string xSubject)
        {
            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = 530f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            float[] tableWidths = new float[2];
            tableWidths[0] = 400f;
            tableWidths[1] = 130f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;
            var normal = getFont("normal");
            Chunk blank = new Chunk("", normal);
            //----------------NEW ROW-----------------------------
            Phrase p = new Phrase();
            var bold = getFont("bold");
            p.Add(new Chunk("เลขที่เอกสาร  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xDocNo, normal));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk("", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xFormNo, normal));

            PdfPCell cell1 = new PdfPCell(p);
            cell1.Border = Rectangle.NO_BORDER;

            table.AddCell(cell1);
            //-----------------NEW ROW --------------------------
            p = new Phrase();
            p.Add(new Chunk("จาก  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xFrom + " (" + xFrPosition + ")", normal));

            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk("เรียน  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xTo, normal));
            cell1 = new PdfPCell(p);
            cell1.Border = Rectangle.NO_BORDER;

            table.AddCell(cell1);
            // --------------------NEW ROW --------------------------------
            p = new Phrase();
            p.Add(new Chunk("วันที่  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xCreateDate, normal));

            //p = new Phrase();
            //p.Add(new Chunk("  ", bold));
            //p.Add(new Chunk(blank));
            //p.Add(new Chunk("  ", normal));

            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk("  ", bold));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);

            //-----------------NEW ROW --------------------------

            p = new Phrase();
            p.Add(new Chunk("เรื่อง  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xSubject, normal));

            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.Colspan = 2;

            table.AddCell(cell0);

            return table;
        }
        private PdfPTable GetHeaderDetail(string xFormNo, string xDocNo, string xDivision, string xFrom, string xTo, string xSubject)
        {
            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = 530f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            float[] tableWidths = new float[2];
            tableWidths[0] = 400f;
            tableWidths[1] = 130f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;
            var normal = getFont("normal");
            Chunk blank = new Chunk("", normal);
            //----------------NEW ROW-----------------------------
            Phrase p = new Phrase();
            var bold = getFont("bold");
            p.Add(new Chunk("เลขที่เอกสาร  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xDocNo, normal));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk("", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xFormNo, normal));

            PdfPCell cell1 = new PdfPCell(p);
            cell1.Border = Rectangle.NO_BORDER;

            table.AddCell(cell1);
            //-----------------NEW ROW --------------------------
            p = new Phrase();
            p.Add(new Chunk("จาก  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xFrom + " (" + xDivision + ")", normal));

            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk("เรียน  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xTo, normal));
            cell1 = new PdfPCell(p);
            cell1.Border = Rectangle.NO_BORDER;

            table.AddCell(cell1);
            // --------------------NEW ROW --------------------------------
            p = new Phrase();
            p.Add(new Chunk("วันที่  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(System.DateTime.Now.ToString("dd MMM yyyy"), normal));

            //p = new Phrase();
            //p.Add(new Chunk("  ", bold));
            //p.Add(new Chunk(blank));
            //p.Add(new Chunk("  ", normal));

            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk("  ", bold));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);

            //-----------------NEW ROW --------------------------

            p = new Phrase();
            p.Add(new Chunk("เรื่อง  ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xSubject, normal));

            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.Colspan = 2;

            table.AddCell(cell0);

            return table;
        }
        private PdfPTable GetBodyObjective(string xObjective)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 530f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            //float[] tableWidths = new float[2];
            //tableWidths[0] = 400f;
            //tableWidths[1] = 130f;

            float[] tableWidths = new float[1];
            tableWidths[0] = 530f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk blank = new Chunk("", bold);

            Phrase p = new Phrase();

            p.Add(new Chunk("วัตถุประสงค์ ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xObjective, normal));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);
            return table;
        }
        private PdfPTable GetBodyCC(string xCC)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 530f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            //float[] tableWidths = new float[2];
            //tableWidths[0] = 400f;
            //tableWidths[1] = 130f;

            float[] tableWidths = new float[1];
            tableWidths[0] = 530f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk blank = new Chunk("", bold);

            Phrase p = new Phrase();

            p.Add(new Chunk("สำเนาถึง ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk(xCC, normal));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);
            return table;
        }
        private PdfPTable GetBodySubRevision(string xSubRevisionList)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = 550f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            float[] tableWidths = new float[2];
            tableWidths[0] = 200f;
            tableWidths[1] = 250f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Phrase p = new Phrase();

            // List of Data
            string[] arrSubRevision = xSubRevisionList.Split(new string[] { "_newline_" }, StringSplitOptions.None);
            for (int i = 0; i < arrSubRevision.Length; i++)
            {
                string[] arrSubRevisionDetail = arrSubRevision[i].Split(new string[] { "_atos_" }, StringSplitOptions.None);
                for (int j = 0; j < arrSubRevisionDetail.Length; j++)
                {
                    p = new Phrase();
                    if (i == 0)
                        p.Add(new Chunk(arrSubRevisionDetail[j].ToString(), bold));
                    else
                        p.Add(new Chunk(arrSubRevisionDetail[j].ToString(), normal));
                    PdfPCell cell1 = new PdfPCell(p);
                    cell1.Border = Rectangle.NO_BORDER;
                    cell1.NoWrap = false;
                    table.AddCell(cell1);
                }
            }

            p = new Phrase();
            p.Add(new Chunk(" ", normal));
            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.Colspan = 2;
            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk("เพื่อโปรดพิจารณาลงนาม", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.Colspan = 2;
            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk(" ", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.Colspan = 2;
            table.AddCell(cell0);

            return table;
        }
        private PdfPTable GetBodyAttachment(string[] xAttachments)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = 450f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            //float[] tableWidths = new float[2];
            //tableWidths[0] = 400f;
            //tableWidths[1] = 130f;

            float[] tableWidths = new float[2];
            tableWidths[0] = 20f;
            tableWidths[1] = 400f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk blank = new Chunk("", bold);

            Phrase p = new Phrase();

            p.Add(new Chunk("เอกสารแนบ ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk("", normal));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.Colspan = 2;
            table.AddCell(cell0);

            // List of Attachment
            //for (int i = 0; i < xAttachments.Length; i++)
            //{
            p = new Phrase();
            p.Add(new Chunk("1", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.NoWrap = true;
            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk("Price schedule", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.NoWrap = false;
            table.AddCell(cell0);
            //}
            return table;
        }
        private PdfPTable GetBodyDocApprove(string strContent)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = 450f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            //float[] tableWidths = new float[2];
            //tableWidths[0] = 400f;
            //tableWidths[1] = 130f;

            float[] tableWidths = new float[2];
            tableWidths[0] = 20f;
            tableWidths[1] = 400f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk blank = new Chunk("", bold);

            Phrase p = new Phrase();

            p.Add(new Chunk("เนื้อหา ", bold));
            p.Add(new Chunk(blank));
            p.Add(new Chunk("", normal));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.Colspan = 2;
            table.AddCell(cell0);

            // List of Attachment
            //for (int i = 0; i < xAttachments.Length; i++)
            //{
            p = new Phrase();
            p.Add(new Chunk("-", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.NoWrap = true;
            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk(strContent, normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.NoWrap = false;
            table.AddCell(cell0);
            //}
            return table;
        }
        private PdfPTable GetBodyFromDataTable(string xTitleTable, DataTable dt, int xTotalColumns, float tableWidth, float[] tableWidths)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            PdfPTable table = new PdfPTable(xTotalColumns);
            table.TotalWidth = tableWidth;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            //float[] tableWidths = new float[2];
            //tableWidths[0] = 400f;
            //tableWidths[1] = 130f;


            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk blank = new Chunk("", bold);
            // Title of Table 
            Phrase p = new Phrase();
            p.Add(new Chunk(xTitleTable, bold));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.Colspan = xTotalColumns;
            table.AddCell(cell0);

            // Table Header
            for (int b = 0; b < dt.Columns.Count; b++)
            {
                p = new Phrase();
                p.Add(new Chunk(dt.Columns[b].ColumnName, bold));
                cell0 = new PdfPCell(p);
                cell0.Border = Rectangle.BOX;
                table.AddCell(cell0);
            }
            // List of Data
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                for (int b = 0; b < dt.Columns.Count; b++)
                {
                    p = new Phrase();
                    p.Add(new Chunk(dt.Rows[a][b].ToString(), normal));
                    cell0 = new PdfPCell(p);
                    cell0.Border = Rectangle.BOX;
                    table.AddCell(cell0);
                }
            }
            return table;
        }
        private PdfPTable GetBodyParagraph(string xText)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 530f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            //float[] tableWidths = new float[2];
            //tableWidths[0] = 400f;
            //tableWidths[1] = 130f;

            float[] tableWidths = new float[1];
            tableWidths[0] = 500f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk newBlankParagraph = new Chunk("          ", normal);

            Phrase p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk(xText, normal));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);
            return table;
        }
        private PdfPTable GetBodyTopic(string xText, bool _isBold)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 530f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            float[] tableWidths = new float[1];
            tableWidths[0] = 530f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Phrase p = new Phrase();
            if (_isBold == true)
            {
                p.Add(new Chunk(xText, bold));
            }
            else
            {
                p.Add(new Chunk(xText, normal));
            }

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);
            return table;
        }
        public PdfPTable GetBodySignature(bool isApprover, string xFullName, string xPosition, string xDateString)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            var normal_blue = getFont("normal_blue");
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 250f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            string[] listDate = xDateString.Split(' ');
            int year_date = int.Parse(listDate[2]);
            int year_now = (int.Parse(DateTime.Now.ToString("yyyy"))) + 543;
            if (year_date < year_now - 5)
            {
                xDateString = "";
            }

            float[] tableWidths = new float[1];
            tableWidths[0] = 250f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk newBlankParagraph = new Chunk("          ", normal);
            Phrase p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            if (isApprover == true)
            {
                p.Add(new Chunk("ผู้อนุมัติลงนาม                            ", normal));
            }
            else
            {
                p.Add(new Chunk("ลงนาม                                 ", normal));
            }
            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk("      ", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            //p = new Phrase();
            //p.Add(new Chunk(newBlankParagraph));
            //p.Add(new Chunk("-------------------------------------------", normal));
            //cell0 = new PdfPCell(p);
            //cell0.Border = Rectangle.NO_BORDER;
            //cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            //table.AddCell(cell0);
            p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk("     " + xFullName + "", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk("     " + xPosition + "    ", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            if (xDateString != "")
            {
                DateTime old_date = DateTime.Parse(xDateString);
                xDateString = convertDate(old_date);
            }
            p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk("     วันที่ " + xDateString + "    ", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            string sign_digital = "";
            if (xDateString != "")
            {
                sign_digital = "     ลงนามผ่านระบบอิเล็กทรอนิกส์";
            }
            p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk(sign_digital, normal_blue));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            return table;
        }
        public PdfPTable GetBodySignature(bool isApprover, string xFullName, string xPosition, string xPositionFull, string xDateString)
        {
            var bold = getFont("bold");
            var normal = getFont("normal");
            var normal_blue = getFont("normal_blue");
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 270f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            string[] listDate = xDateString.Split(' ');
            int year_date = int.Parse(listDate[2]);
            int year_now = (int.Parse(DateTime.Now.ToString("yyyy")));
            if (year_date < year_now - 5)
            {
                xDateString = "";
            }

            float[] tableWidths = new float[1];
            tableWidths[0] = 270f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk newBlankParagraph = new Chunk("          ", normal);
            Phrase p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            if (isApprover == true)
            {
                p.Add(new Chunk("ผู้อนุมัติลงนาม                            ", normal));
            }
            else
            {
                p.Add(new Chunk("ลงนาม                                 ", normal));
            }
            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell0);

            p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk("      ", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            //p = new Phrase();
            //p.Add(new Chunk(newBlankParagraph));
            //p.Add(new Chunk("-------------------------------------------", normal));
            //cell0 = new PdfPCell(p);
            //cell0.Border = Rectangle.NO_BORDER;
            //cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            //table.AddCell(cell0);
            p = new Phrase();
            //p.Add(new Chunk(newBlankParagraph));
            //p.Add(new Chunk("        " + xFullName + "", normal));
            p.Add(new Chunk(xFullName, normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            p = new Phrase();
            //p.Add(new Chunk(newBlankParagraph));
            //p.Add(new Chunk("      " + xPositionFull + " (" + xPosition + ")    ", normal));
            //p.Add(new Chunk("      " + xPositionFull, normal));
            p.Add(new Chunk(xPositionFull, normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            if (xDateString != "")
            {
                DateTime old_date = DateTime.Parse(xDateString);
                xDateString = convertDate(old_date);
            }
            p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk("     วันที่ " + xDateString + "    ", normal));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            string sign_digital = "";
            if (xDateString != "")
            {
                sign_digital = "     ลงนามผ่านระบบอิเล็กทรอนิกส์";
            }
            p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk(sign_digital, normal_blue));
            cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell0);

            return table;
        }
        public PdfPTable GetFooter(string xText)
        {
            var bold = getFont("bold");
            var normal_blue = getFont("normal_blue");
            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 530f;
            table.HorizontalAlignment = 0;
            table.SpacingAfter = 10;

            float[] tableWidths = new float[1];
            tableWidths[0] = 500f;

            table.SetWidths(tableWidths);
            table.LockedWidth = true;

            Chunk newBlankParagraph = new Chunk("   ", normal_blue);

            Phrase p = new Phrase();
            p.Add(new Chunk(newBlankParagraph));
            p.Add(new Chunk(xText, normal_blue));

            PdfPCell cell0 = new PdfPCell(p);
            cell0.Border = Rectangle.NO_BORDER;

            table.AddCell(cell0);
            return table;
        }
        public Document GetPDFDocFrGridview(Control gv1, HttpResponse Response)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            return pdfDoc;
        }
        public void createMemo(string xFormNo, string xDocRunno
            , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition
            , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition
            , string xSubject, string xObjective, string[] xAttachments
            , string[] xParagraphContents, string xcc
            , HttpResponse Response)
        {


            try
            {
                // Create PDF document

                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                pdfDoc.Open();
                // Add Header
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                LineSeparator line = new LineSeparator();

                pdfDoc.Add(line);
                // Copy To
                pdfDoc.Add(GetBodyCC(xcc));
                // Add Body Objective
                //pdfDoc.Add(GetBodyObjective(xObjective));
                // Add Body Attachment
                if (xAttachments.Length > 0)
                {
                    //string[] xAttachment = new string[1];
                    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                    pdfDoc.Add(GetBodyAttachment(xAttachments));
                }
                pdfDoc.Add(GetBodyTopic("ข้อความ", true));
                string xbody1 = "";
                if (xParagraphContents.Length > 0)
                {
                    for (int i = 0; i < xParagraphContents.Length; i++)
                    {
                        if ((xParagraphContents[i] != null) && (xParagraphContents[i].ToString() != ""))
                        {
                            xbody1 = xParagraphContents[i];
                            if ((xbody1.IndexOf("_atos_") > 0) && (xbody1.IndexOf("_newline_") > 0))
                                pdfDoc.Add(GetBodySubRevision(xbody1));
                            else
                                pdfDoc.Add(GetBodyParagraph(xbody1));
                        }
                    }
                }



                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.TotalWidth = 530f;
                float[] xcolumnsWidth = new float[2];
                xcolumnsWidth[0] = 265f;
                xcolumnsWidth[1] = 265f;

                PdfPCell cell0 = new PdfPCell(GetBodySignature(false, xFrFullname, xFrPosition, System.DateTime.Now.ToString("dd/MM/yyyy")));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(false, "นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                cell0 = new PdfPCell(GetBodySignature(true, xToFullname, xToPosition, System.DateTime.Now.ToString("dd/MM/yyyy")));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(true, "วิชาญ เก่งเชี่ยวชาญ", "หัวหน้าโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfDoc.Add(signatureTable);
                //pdfDoc.Add(GetBodySignature(false,"นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content - disposition", "attachment; filename = Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                //Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public byte[] createMemoByte(string xFormNo, string xDocRunno, string xCreateDate
            , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition, string xFrSubmitDate
            , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition, string xToSubmitDate
            , string[] text, string xSubject, string xObjective, string[] xAttachments
            , string[] xParagraphContents, string xcc
            , HttpResponse Response)
        {
            DateTime datetime = DateTime.Parse(xToSubmitDate);
            //System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("th-TH");
            //String strDate = datetime.ToString("dd-MM-yyyy");
            //DateTime dateThai = Convert.ToDateTime(strDate, _cultureTHInfo);
            //xToSubmitDate = dateThai.ToString("dd MMM yy");
            xToSubmitDate = datetime.ToString("dd MMM yyyy");

            byte[] file = null;
            try
            {
                // Create PDF document
                MemoryStream stream = new MemoryStream();
                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                pdfDoc.Open();
                // Add Header
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                LineSeparator line = new LineSeparator();

                pdfDoc.Add(line);
                // Copy To
                pdfDoc.Add(GetBodyCC(xcc));
                // Add Body Objective
                //pdfDoc.Add(GetBodyObjective(xObjective));
                // Add Body Attachment
                //if (xAttachments.Length > 0)
                //{
                //    //string[] xAttachment = new string[1];
                //    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                //    pdfDoc.Add(GetBodyAttachment(xAttachments));
                //}
                pdfDoc.Add(GetBodyTopic("ข้อความ", true));
                string xbody1 = "";
                if (xParagraphContents.Length > 0)
                {
                    for (int i = 0; i < xParagraphContents.Length; i++)
                    {
                        if ((xParagraphContents[i] != null) && (xParagraphContents[i].ToString() != ""))
                        {
                            xbody1 = xParagraphContents[i];
                            if ((xbody1.IndexOf("_atos_") > 0) && (xbody1.IndexOf("_newline_") > 0))
                                pdfDoc.Add(GetBodySubRevision(xbody1));
                            else
                                pdfDoc.Add(GetBodyParagraph(xbody1));
                        }
                    }
                }


                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.TotalWidth = 530f;
                float[] xcolumnsWidth = new float[2];
                xcolumnsWidth[0] = 265f;
                xcolumnsWidth[1] = 265f;

                PdfPCell cell0 = new PdfPCell(new Paragraph(""));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(false, "นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                cell0 = new PdfPCell(GetBodySignature(true, xToFullname, xToPosition, xToSubmitDate));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(true, "วิชาญ เก่งเชี่ยวชาญ", "หัวหน้าโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfDoc.Add(signatureTable);
                //pdfDoc.Add(GetBodySignature(false,"นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                string textfooter = "";
                if (text.Length > 0)
                {
                    for (int i = text.Length - 1; i >= 0; i--)
                    {
                        textfooter = text[i];
                        pdfDoc.Add(GetFooter(textfooter));
                    }
                }

                PdfPTable footerTable = new PdfPTable(1);
                footerTable.SpacingAfter = 10;
                var normal = getFont("normal");
                Chunk newBlankParagraph = new Chunk("", normal);
                Phrase p = new Phrase();
                p.Add(new Chunk(newBlankParagraph));
                //p.Add(new Chunk("หมายเหตุ: อนุมัติภายในระบบ", normal));
                PdfPCell cellfooter = new PdfPCell(p);
                cellfooter.Border = Rectangle.NO_BORDER;
                footerTable.AddCell(cellfooter);
                pdfDoc.Add(footerTable);

                if (xAttachments.Length > 0)
                {
                    pdfDoc.NewPage();

                    pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                    pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                    //LineSeparator line = new LineSeparator();

                    pdfDoc.Add(line);

                    //Add Body Attachment
                    if (xAttachments.Length > 0)
                    {
                        //string[] xAttachment = new string[1];
                        //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                        pdfDoc.Add(GetBodyAttachment(xAttachments));
                    }
                }

                pdfWriter.CloseStream = false;
                pdfDoc.Close();

                file = stream.ToArray();

                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content - disposition", "attachment; filename = Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                //Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            return file;
        }

        public byte[] createMemoByte(string xFormNo, string xDocRunno, string xCreateDate
            , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition, string xFrPositionFull, string xFrSubmitDate
            , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition, string xToPositionFull, string xToSubmitDate
            , string[] text, string xSubject, string xObjective, string[] xAttachments
            , string[] xParagraphContents, string xcc, bool isShowHeaderPage_Attachment = true
            )
        {
            DateTime datetime = DateTime.Parse(xToSubmitDate);
            //System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("th-TH");
            //String strDate = datetime.ToString("dd-MM-yyyy");
            //DateTime dateThai = Convert.ToDateTime(strDate, _cultureTHInfo);
            //xToSubmitDate = dateThai.ToString("dd MMM yy");
            xToSubmitDate = datetime.ToString("dd MMM yyyy");

            byte[] file = null;
            try
            {
                // Create PDF document
                MemoryStream stream = new MemoryStream();
                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                pdfDoc.Open();
                // Add Header
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                LineSeparator line = new LineSeparator();

                pdfDoc.Add(line);
                // Copy To
                pdfDoc.Add(GetBodyCC(xcc));
                // Add Body Objective
                //pdfDoc.Add(GetBodyObjective(xObjective));
                // Add Body Attachment
                //if (xAttachments.Length > 0)
                //{
                //    //string[] xAttachment = new string[1];
                //    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                //    pdfDoc.Add(GetBodyAttachment(xAttachments));
                //}
                pdfDoc.Add(GetBodyTopic("ข้อความ", true));
                string xbody1 = "";
                if (xParagraphContents.Length > 0)
                {
                    for (int i = 0; i < xParagraphContents.Length; i++)
                    {
                        if ((xParagraphContents[i] != null) && (xParagraphContents[i].ToString() != ""))
                        {
                            xbody1 = xParagraphContents[i];
                            if ((xbody1.IndexOf("_atos_") > 0) && (xbody1.IndexOf("_newline_") > 0))
                                pdfDoc.Add(GetBodySubRevision(xbody1));
                            else
                                pdfDoc.Add(GetBodyParagraph(xbody1));
                        }
                    }
                }


                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.TotalWidth = 530f;
                float[] xcolumnsWidth = new float[2];
                xcolumnsWidth[0] = 265f;
                xcolumnsWidth[1] = 265f;

                PdfPCell cell0 = new PdfPCell(new Paragraph(""));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(false, "นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                cell0 = new PdfPCell(GetBodySignature(true, xToFullname, xToPosition, xToPositionFull, xToSubmitDate));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(true, "วิชาญ เก่งเชี่ยวชาญ", "หัวหน้าโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfDoc.Add(signatureTable);
                //pdfDoc.Add(GetBodySignature(false,"นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                string textfooter = "";
                if (text.Length > 0)
                {
                    for (int i = text.Length - 1; i >= 0; i--)
                    {
                        textfooter = text[i];
                        pdfDoc.Add(GetFooter(textfooter));
                    }
                }

                PdfPTable footerTable = new PdfPTable(1);
                footerTable.SpacingAfter = 10;
                var normal = getFont("normal");
                Chunk newBlankParagraph = new Chunk("", normal);
                Phrase p = new Phrase();
                p.Add(new Chunk(newBlankParagraph));
                //p.Add(new Chunk("หมายเหตุ: อนุมัติภายในระบบ", normal));
                PdfPCell cellfooter = new PdfPCell(p);
                cellfooter.Border = Rectangle.NO_BORDER;
                footerTable.AddCell(cellfooter);
                pdfDoc.Add(footerTable);

                //if (xAttachments.Length > 0)
                //{
                //    pdfDoc.NewPage();

                //    //Add Body Attachment
                //    if (isShowHeaderPage_Attachment == true)
                //    {
                //        pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                //        pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                //        pdfDoc.Add(line);
                //    }

                //    //string[] xAttachment = new string[1];
                //    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                //    pdfDoc.Add(GetBodyAttachment(xAttachments));
                //}

                pdfWriter.CloseStream = false;
                pdfDoc.Close();

                file = stream.ToArray();

                //Response.Buffer = true;
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content - disposition", "attachment; filename = Example.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Write(pdfDoc);
                //Response.End();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
            return file;
        }
        public byte[] createAttachmentByte(string xFormNo, string xDocRunno, string xCreateDate
           , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition, string xFrPositionFull, string xFrSubmitDate
           , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition, string xToPositionFull, string xToSubmitDate
           , string[] text, string xSubject, string xObjective, string[] xAttachments
           , string[] xParagraphContents, string xcc, bool isShowHeaderPage_Attachment = true
           )
        {
            DateTime datetime = DateTime.Parse(xToSubmitDate);
            xToSubmitDate = datetime.ToString("dd MMM yyyy");
            byte[] file = null;
            try
            {
                if (xAttachments.Length > 0)
                {
                    // Create PDF document
                    MemoryStream stream = new MemoryStream();
                    Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    LineSeparator line = new LineSeparator();

                    pdfDoc.Open();

                    //Add Body Attachment
                    if (isShowHeaderPage_Attachment == true)
                    {
                        pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                        pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                        pdfDoc.Add(line);
                    }

                    pdfDoc.Add(GetBodyAttachment(xAttachments));

                    pdfWriter.CloseStream = false;
                    pdfDoc.Close();

                    file = stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteEx(ex);
            }
            return file;
        }
         
        public byte[] createMemoDocApproveByte(string xFormNo, string xDocRunno, string xCreateDate
          , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition, string xFrPositionFull, string xFrSubmitDate
          , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition, string xToPositionFull, string xToSubmitDate
          , string xSubject, string xContent)
        {
            DateTime datetime = DateTime.Parse(xToSubmitDate);
            xToSubmitDate = datetime.ToString("dd MMM yyyy");
            byte[] file = null;
            try
            {

                // Create PDF document
                MemoryStream stream = new MemoryStream();
                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                LineSeparator line = new LineSeparator();

                pdfDoc.Open();

                //Add Body Attachment
                //if (isShowHeaderPage_Attachment == true)
                //{
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                pdfDoc.Add(line);
                // }

                pdfDoc.Add(GetBodyDocApprove(xContent));

                pdfWriter.CloseStream = false;
                pdfDoc.Close();

                file = stream.ToArray();

            }
            catch (Exception ex)
            {
                LogHelper.WriteEx(ex);
            }
            return file;
        }

        public string changeDateTimetoDate(string datetime)
        {
            string date = "";
            if (datetime != "")
            {
                DateTime newDateTime = DateTime.Parse(datetime);
                date = convertDate(newDateTime);
                //date = newDateTime.ToString("dd MMM yyyy");
            }
            return date;
        }
        public byte[] createMemoApvByte(string xFormNo, string xDocRunno, string xCreateDate
         , string xFrFullname, string xFrPosition,string xToFullname, string xToPosition, string xToPositionFull, string xToSubmitDate
         , string xSubject, string xContent ,string [] approvers)
        {
            DateTime datetime = DateTime.Parse(xToSubmitDate);
            xToSubmitDate = datetime.ToString("dd MMM yyyy");
            byte[] file = null;
            try
            {

                // Create PDF document
                MemoryStream stream = new MemoryStream();
                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                LineSeparator line = new LineSeparator();

                pdfDoc.Open();
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));
                pdfDoc.Add(line);
                pdfDoc.Add(GetBodyDocApprove(xContent));




                // footer approver
                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.TotalWidth = 530f;
                float[] xcolumnsWidth = new float[2];
                xcolumnsWidth[0] = 265f;
                xcolumnsWidth[1] = 265f;

                PdfPCell cell0 = new PdfPCell(new Paragraph(""));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(false, "นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                cell0 = new PdfPCell(GetBodySignature(true, xToFullname, xToPosition, xToPositionFull, xToSubmitDate));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(true, "วิชาญ เก่งเชี่ยวชาญ", "หัวหน้าโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfDoc.Add(signatureTable);
                //pdfDoc.Add(GetBodySignature(false,"นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                string textfooter = "";
                if (approvers.Length > 0)
                {
                    for (int i = approvers.Length - 1; i >= 0; i--)
                    {
                        textfooter = approvers[i];
                        pdfDoc.Add(GetFooter(textfooter));
                    }
                }

                PdfPTable footerTable = new PdfPTable(1);
                footerTable.SpacingAfter = 10;
                var normal = getFont("normal");
                Chunk newBlankParagraph = new Chunk("", normal);
                Phrase p = new Phrase();
                p.Add(new Chunk(newBlankParagraph));
                //p.Add(new Chunk("หมายเหตุ: อนุมัติภายในระบบ", normal));
                PdfPCell cellfooter = new PdfPCell(p);
                cellfooter.Border = Rectangle.NO_BORDER;
                footerTable.AddCell(cellfooter);
                pdfDoc.Add(footerTable);
                // footer approver



                pdfWriter.CloseStream = false;
                pdfDoc.Close();

                file = stream.ToArray();

            }
            catch (Exception ex)
            {
                LogHelper.WriteEx(ex);
            }
            return file;
        }

        public byte[] createMemoByteNoCC(string xFormNo, string xDocRunno, string xCreateDate
            , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition, string xFrSubmitDate
            , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition, string xToSubmitDate
            , string[] text, string xSubject, string xObjective, string[] xAttachments
            , string[] xParagraphContents, string xcc
            , HttpResponse Response)
        {
            DateTime datetime = DateTime.Parse(xToSubmitDate);
            //System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("th-TH");
            //String strDate = datetime.ToString("dd-MM-yyyy");
            //DateTime dateThai = Convert.ToDateTime(strDate, _cultureTHInfo);
            //xToSubmitDate = dateThai.ToString("dd MMM yy");
            xToSubmitDate = datetime.ToString("dd MMM yyyy");

            byte[] file = null;
            try
            {
                // Create PDF document
                MemoryStream stream = new MemoryStream();
                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                pdfDoc.Open();
                // Add Header
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                LineSeparator line = new LineSeparator();

                pdfDoc.Add(line);
                // Copy To
                //pdfDoc.Add(GetBodyCC(xcc));
                // Add Body Objective
                //pdfDoc.Add(GetBodyObjective(xObjective));
                // Add Body Attachment
                //if (xAttachments.Length > 0)
                //{
                //    //string[] xAttachment = new string[1];
                //    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                //    pdfDoc.Add(GetBodyAttachment(xAttachments));
                //}
                pdfDoc.Add(GetBodyTopic("", true));
                string xbody1 = "";
                if (xParagraphContents.Length > 0)
                {
                    for (int i = 0; i < xParagraphContents.Length; i++)
                    {
                        if ((xParagraphContents[i] != null) && (xParagraphContents[i].ToString() != ""))
                        {
                            xbody1 = xParagraphContents[i];
                            if ((xbody1.IndexOf("_atos_") > 0) && (xbody1.IndexOf("_newline_") > 0))
                                pdfDoc.Add(GetBodySubRevision(xbody1));
                            else
                                pdfDoc.Add(GetBodyParagraph(xbody1));
                        }
                    }
                }


                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.TotalWidth = 530f;
                float[] xcolumnsWidth = new float[2];
                xcolumnsWidth[0] = 265f;
                xcolumnsWidth[1] = 265f;

                PdfPCell cell0 = new PdfPCell(new Paragraph(""));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(false, "นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                cell0 = new PdfPCell(GetBodySignature(true, xToFullname, xToPosition, xToSubmitDate));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(true, "วิชาญ เก่งเชี่ยวชาญ", "หัวหน้าโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfDoc.Add(signatureTable);
                //pdfDoc.Add(GetBodySignature(false,"นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                string textfooter = "";
                if (text.Length > 0)
                {
                    for (int i = text.Length - 1; i >= 0; i--)
                    {
                        textfooter = text[i];
                        pdfDoc.Add(GetFooter(textfooter));
                    }
                }
                if (xAttachments.Length > 0)
                {
                    pdfDoc.NewPage();

                    PdfPTable footerTable = new PdfPTable(1);
                    footerTable.SpacingAfter = 10;
                    var normal = getFont("normal");
                    Chunk newBlankParagraph = new Chunk("", normal);
                    Phrase p = new Phrase();
                    p.Add(new Chunk(newBlankParagraph));
                    //p.Add(new Chunk("หมายเหตุ: อนุมัติภายในระบบ", normal));
                    PdfPCell cellfooter = new PdfPCell(p);
                    cellfooter.Border = Rectangle.NO_BORDER;
                    footerTable.AddCell(cellfooter);
                    pdfDoc.Add(footerTable);

                    pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                    pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                    //LineSeparator line = new LineSeparator();

                    pdfDoc.Add(line);

                    //Add Body Attachment
                    if (xAttachments.Length > 0)
                    {
                        //string[] xAttachment = new string[1];
                        //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                        pdfDoc.Add(GetBodyAttachment(xAttachments));
                    }
                }
                pdfWriter.CloseStream = false;
                pdfDoc.Close();

                file = stream.ToArray();

                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content - disposition", "attachment; filename = Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                //Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            return file;
        }

        public byte[] createMemoByteNoCC(string xFormNo, string xDocRunno, string xCreateDate
            , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition, string xFrPositionFull, string xFrSubmitDate
            , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition, string xToPositionFull, string xToSubmitDate
            , string[] text, string xSubject, string xObjective, string[] xAttachments
            , string[] xParagraphContents, string xcc
            )
        {
            DateTime datetime = DateTime.Parse(xToSubmitDate);
            //System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("th-TH");
            //String strDate = datetime.ToString("dd-MM-yyyy");
            //DateTime dateThai = Convert.ToDateTime(strDate, _cultureTHInfo);
            //xToSubmitDate = dateThai.ToString("dd MMM yy");
            xToSubmitDate = datetime.ToString("dd MMM yyyy");

            byte[] file = null;
            try
            {
                // Create PDF document
                MemoryStream stream = new MemoryStream();
                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                pdfDoc.Open();
                // Add Header
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                LineSeparator line = new LineSeparator();

                pdfDoc.Add(line);
                // Copy To
                //pdfDoc.Add(GetBodyCC(xcc));
                // Add Body Objective
                //pdfDoc.Add(GetBodyObjective(xObjective));
                // Add Body Attachment
                //if (xAttachments.Length > 0)
                //{
                //    //string[] xAttachment = new string[1];
                //    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                //    pdfDoc.Add(GetBodyAttachment(xAttachments));
                //}
                pdfDoc.Add(GetBodyTopic("", true));
                string xbody1 = "";
                if (xParagraphContents.Length > 0)
                {
                    for (int i = 0; i < xParagraphContents.Length; i++)
                    {
                        if ((xParagraphContents[i] != null) && (xParagraphContents[i].ToString() != ""))
                        {
                            xbody1 = xParagraphContents[i];
                            if ((xbody1.IndexOf("_atos_") > 0) && (xbody1.IndexOf("_newline_") > 0))
                                pdfDoc.Add(GetBodySubRevision(xbody1));
                            else
                                pdfDoc.Add(GetBodyParagraph(xbody1));
                        }
                    }
                }

                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.TotalWidth = 530f;
                float[] xcolumnsWidth = new float[2];
                xcolumnsWidth[0] = 265f;
                xcolumnsWidth[1] = 265f;

                PdfPCell cell0 = new PdfPCell(new Paragraph(""));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(false, "นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                cell0 = new PdfPCell(GetBodySignature(true, xToFullname, xToPosition, xToPositionFull, xToSubmitDate));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(true, "วิชาญ เก่งเชี่ยวชาญ", "หัวหน้าโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfDoc.Add(signatureTable);
                //pdfDoc.Add(GetBodySignature(false,"นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                string textfooter = "";
                if (text.Length > 0)
                {
                    for (int i = text.Length - 1; i >= 0; i--)
                    {
                        textfooter = text[i];
                        pdfDoc.Add(GetFooter(textfooter));
                    }
                }
                if (xAttachments.Length > 0)
                {
                    pdfDoc.NewPage();

                    PdfPTable footerTable = new PdfPTable(1);
                    footerTable.SpacingAfter = 10;
                    var normal = getFont("normal");
                    Chunk newBlankParagraph = new Chunk("", normal);
                    Phrase p = new Phrase();
                    p.Add(new Chunk(newBlankParagraph));
                    //p.Add(new Chunk("หมายเหตุ: อนุมัติภายในระบบ", normal));
                    PdfPCell cellfooter = new PdfPCell(p);
                    cellfooter.Border = Rectangle.NO_BORDER;
                    footerTable.AddCell(cellfooter);
                    pdfDoc.Add(footerTable);

                    pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                    pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                    //LineSeparator line = new LineSeparator();

                    pdfDoc.Add(line);

                    //Add Body Attachment
                    if (xAttachments.Length > 0)
                    {
                        //string[] xAttachment = new string[1];
                        //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                        pdfDoc.Add(GetBodyAttachment(xAttachments));
                    }
                }
                pdfWriter.CloseStream = false;
                pdfDoc.Close();

                file = stream.ToArray();

                //Response.Buffer = true;
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content - disposition", "attachment; filename = Example.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Write(pdfDoc);
                //Response.End();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
            return file;
        }

        public byte[] createMemoByteNoCC_SP_DTS_SC(string xFormNo, string xDocRunno, string xCreateDate
            , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition, string xFrPositionFull, string xFrSubmitDate
            , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition, string xToPositionFull, string xToSubmitDate
            , string[] text, string xSubject, string xObjective, string[] xAttachments
            , string[] xParagraphContents, string xcc
            )
        {
            DateTime datetime = DateTime.Parse(xToSubmitDate);
            //System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("th-TH");
            //String strDate = datetime.ToString("dd-MM-yyyy");
            //DateTime dateThai = Convert.ToDateTime(strDate, _cultureTHInfo);
            //xToSubmitDate = dateThai.ToString("dd MMM yy");
            xToSubmitDate = datetime.ToString("dd MMM yyyy");

            byte[] file = null;
            try
            {
                // Create PDF document
                MemoryStream stream = new MemoryStream();
                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                pdfDoc.Open();
                // Add Header
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                LineSeparator line = new LineSeparator();

                pdfDoc.Add(line);
                // Copy To
                pdfDoc.Add(GetBodyCC(xcc));
                // Add Body Objective
                //pdfDoc.Add(GetBodyObjective(xObjective));
                // Add Body Attachment
                //if (xAttachments.Length > 0)
                //{
                //    //string[] xAttachment = new string[1];
                //    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                //    pdfDoc.Add(GetBodyAttachment(xAttachments));
                //}
                pdfDoc.Add(GetBodyTopic("", true));
                string xbody1 = "";
                if (xParagraphContents.Length > 0)
                {
                    for (int i = 0; i < xParagraphContents.Length; i++)
                    {
                        if ((xParagraphContents[i] != null) && (xParagraphContents[i].ToString() != ""))
                        {
                            xbody1 = xParagraphContents[i];
                            if ((xbody1.IndexOf("_atos_") > 0) && (xbody1.IndexOf("_newline_") > 0))
                                pdfDoc.Add(GetBodySubRevision(xbody1));
                            else
                                pdfDoc.Add(GetBodyParagraph(xbody1));
                        }
                    }
                }

                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.TotalWidth = 530f;
                float[] xcolumnsWidth = new float[2];
                xcolumnsWidth[0] = 265f;
                xcolumnsWidth[1] = 265f;

                PdfPCell cell0 = new PdfPCell(new Paragraph(""));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(false, "นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                cell0 = new PdfPCell(GetBodySignature(true, xToFullname, xToPosition, xToPositionFull, xToSubmitDate));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(true, "วิชาญ เก่งเชี่ยวชาญ", "หัวหน้าโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfDoc.Add(signatureTable);
                //pdfDoc.Add(GetBodySignature(false,"นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                string textfooter = "";
                if (text.Length > 0)
                {
                    for (int i = text.Length - 1; i >= 0; i--)
                    {
                        textfooter = text[i];
                        pdfDoc.Add(GetFooter(textfooter));
                    }
                }
                if (xAttachments.Length > 0)
                {
                    pdfDoc.NewPage();

                    PdfPTable footerTable = new PdfPTable(1);
                    footerTable.SpacingAfter = 10;
                    var normal = getFont("normal");
                    Chunk newBlankParagraph = new Chunk("", normal);
                    Phrase p = new Phrase();
                    p.Add(new Chunk(newBlankParagraph));
                    //p.Add(new Chunk("หมายเหตุ: อนุมัติภายในระบบ", normal));
                    PdfPCell cellfooter = new PdfPCell(p);
                    cellfooter.Border = Rectangle.NO_BORDER;
                    footerTable.AddCell(cellfooter);
                    pdfDoc.Add(footerTable);

                    pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                    pdfDoc.Add(GetHeaderDetail(xFormNo, xCreateDate, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                    //LineSeparator line = new LineSeparator();

                    pdfDoc.Add(line);

                    //Add Body Attachment
                    if (xAttachments.Length > 0)
                    {
                        //string[] xAttachment = new string[1];
                        //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                        pdfDoc.Add(GetBodyAttachment(xAttachments));
                    }
                }
                pdfWriter.CloseStream = false;
                pdfDoc.Close();

                file = stream.ToArray();

                //Response.Buffer = true;
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content - disposition", "attachment; filename = Example.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Write(pdfDoc);
                //Response.End();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
            return file;
        }

        public byte[] createMemoByteNoFooter(string xFormNo, string xDocRunno
           , string xFrSectoin, string xFrDepartment, string xFrDivision, string xFrFullname, string xFrPosition
           , string xToSection, string xToDepartment, string xToDivision, string xToFullname, string xToPosition
           , string xSubject, string xObjective, string[] xAttachments
           , string[] xParagraphContents, string xcc
           , HttpResponse Response)
        {

            byte[] file = null;
            try
            {
                // Create PDF document
                MemoryStream stream = new MemoryStream();
                Document pdfDoc = new Document(PageSize.A4, 30, 30, 20, 20);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                pdfDoc.Open();
                // Add Header
                pdfDoc.Add(GetHeader("การไฟฟ้าฝ่ายผลิตแห่งประเทศไทย", "บันทึก"));
                pdfDoc.Add(GetHeaderDetail(xFormNo, xDocRunno, xFrPosition, xFrFullname, xToPosition, xSubject));

                LineSeparator line = new LineSeparator();

                pdfDoc.Add(line);
                // Copy To
                pdfDoc.Add(GetBodyCC(xcc));
                // Add Body Objective
                pdfDoc.Add(GetBodyObjective(xObjective));
                // Add Body Attachment
                if (xAttachments.Length > 0)
                {
                    //string[] xAttachment = new string[1];
                    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                    pdfDoc.Add(GetBodyAttachment(xAttachments));
                }
                pdfDoc.Add(GetBodyTopic("ข้อความ", true));
                string xbody1 = "";
                if (xParagraphContents.Length > 0)
                {
                    for (int i = 0; i < xParagraphContents.Length; i++)
                    {
                        if ((xParagraphContents[i] != null) && (xParagraphContents[i].ToString() != ""))
                        {
                            xbody1 = xParagraphContents[i];
                            if ((xbody1.IndexOf("_atos_") > 0) && (xbody1.IndexOf("_newline_") > 0))
                                pdfDoc.Add(GetBodySubRevision(xbody1));
                            else
                                pdfDoc.Add(GetBodyParagraph(xbody1));
                        }
                    }
                }


                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.TotalWidth = 530f;
                float[] xcolumnsWidth = new float[2];
                xcolumnsWidth[0] = 265f;
                xcolumnsWidth[1] = 265f;

                PdfPCell cell0 = new PdfPCell(GetBodySignature(false, xFrFullname, xFrPosition, System.DateTime.Now.ToString("dd/MM/yyyy")));
                cell0.Border = Rectangle.NO_BORDER;
                cell0.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell0);

                // signatureTable.AddCell(GetBodySignature(false, "นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                PdfPCell cell1 = new PdfPCell(GetBodySignature(true, xToFullname, xToPosition, System.DateTime.Now.ToString("dd/MM/yyyy")));
                cell1.Border = Rectangle.NO_BORDER;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                signatureTable.AddCell(cell1);

                // signatureTable.AddCell(GetBodySignature(true, "วิชาญ เก่งเชี่ยวชาญ", "หัวหน้าโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                pdfDoc.Add(signatureTable);
                //pdfDoc.Add(GetBodySignature(false,"นางนภัสนันท์ จิตรนำทรัพย์", "หัวหน้ากองแผนงานโครงการ", System.DateTime.Now.ToString("dd/MM/yyyy")));

                //string textfooter = "";
                //if (text.Length > 0)
                //{
                //    for (int i = text.Length - 1; i >= 0; i--)
                //    {
                //        textfooter = text[i];
                //        pdfDoc.Add(GetFooter(textfooter));
                //    }
                //}


                PdfPTable footerTable = new PdfPTable(1);
                footerTable.SpacingAfter = 10;
                var normal = getFont("normal");
                Chunk newBlankParagraph = new Chunk("", normal);
                Phrase p = new Phrase();
                p.Add(new Chunk(newBlankParagraph));
                //p.Add(new Chunk("หมายเหตุ: อนุมัติภายในระบบ", normal));
                PdfPCell cellfooter = new PdfPCell(p);
                cellfooter.Border = Rectangle.NO_BORDER;
                footerTable.AddCell(cellfooter);
                pdfDoc.Add(footerTable);

                //Add Body Attachment
                if (xAttachments.Length > 0)
                {
                    //string[] xAttachment = new string[1];
                    //xAttachment[0] = "ตารางรายละเอียด Work Assignment";
                    pdfDoc.Add(GetBodyAttachment(xAttachments));
                }

                pdfWriter.CloseStream = false;
                pdfDoc.Close();

                file = stream.ToArray();

                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content - disposition", "attachment; filename = Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                //Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            return file;
        }

        private string convertDate(DateTime date)
        {
            //string old_date = date.ToString("dd-MM-yyyy");
            //string[] list = old_date.Split('-');
            string[] monthNamesThai = { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤษจิกายน", "ธันวาคม" };
            string day = date.ToString("dd");
            string month = monthNamesThai[int.Parse(date.ToString("MM")) - 1];
            string year = (int.Parse(date.ToString("yyyy")) + 543).ToString();
            string new_date = day + " " + month + " " + year;
            return new_date;
        }
    }
}
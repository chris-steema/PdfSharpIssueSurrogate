using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfSharpIssueSurrogate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            using (XGraphics gfx = XGraphics.FromPdfPage(page))
            {
                // Create a font
                XFont font = new XFont("Segoe UI Symbol", 20, XFontStyle.BoldItalic);

                // Draw the text
                gfx.DrawString("Hello🅐World!", font, XBrushes.Black,
                  new XRect(0, 0, page.Width, page.Height),
                  XStringFormats.Center);
            }

            // Save the document...
            const string filename = "HelloWorld.pdf";
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);

        }
    }
}

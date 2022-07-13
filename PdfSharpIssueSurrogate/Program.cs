using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace PdfSharpIssueSurrogate
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      LoadFont(Properties.Resources.JiyunoTsubasa);
      // Create a new PDF document
      PdfDocument document = new PdfDocument();
      // Create an empty page
      PdfPage page = document.AddPage();

      // Get an XGraphics object for drawing
      using (XGraphics gfx = XGraphics.FromPdfPage(page))
      {
        // Create a font
        XFont font = new XFont(new Font(privateFonts.Families[0], 20, FontStyle.Bold), new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Default));
        //XFont font = new XFont(new Font(privateFonts.Families[0], 20, FontStyle.Bold), new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Automatic));
        //XFont font = new XFont(new Font(privateFonts.Families[0], 20, FontStyle.Bold), new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.None));
        //XFont font = new XFont(new Font(privateFonts.Families[0], 20, FontStyle.Bold), new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always));
        //XFont font = new XFont(new Font(privateFonts.Families[0], 20, FontStyle.Bold), new XPdfFontOptions(PdfFontEncoding.WinAnsi, PdfFontEmbedding.Default));
        //XFont font = new XFont(new Font(privateFonts.Families[0], 20, FontStyle.Bold), new XPdfFontOptions(PdfFontEncoding.WinAnsi, PdfFontEmbedding.Automatic));
        //XFont font = new XFont(new Font(privateFonts.Families[0], 20, FontStyle.Bold), new XPdfFontOptions(PdfFontEncoding.WinAnsi, PdfFontEmbedding.None));
        //XFont font = new XFont(new Font(privateFonts.Families[0], 20, FontStyle.Bold), new XPdfFontOptions(PdfFontEncoding.WinAnsi, PdfFontEmbedding.Always));

        // Draw the text
        gfx.DrawString("Hello🅐World!", font, XBrushes.Black,
          new XRect(0, 0, page.Width, page.Height),
          XStringFormats.Center);
      }

      // Save the document...
      const string filename = "HelloWorld.pdf";
      document.Save(filename);
      // ...and start a viewer.
      _ = Process.Start(filename);

    }

    private static readonly PrivateFontCollection privateFonts = new PrivateFontCollection();

    private static void LoadFont(byte[] fontData)
    {
      int length = fontData.Length;
      IntPtr data = Marshal.AllocCoTaskMem(length);
      Marshal.Copy(fontData, 0, data, length);
      privateFonts.AddMemoryFont(data, length);
      Marshal.FreeCoTaskMem(data);
    }
  }
}

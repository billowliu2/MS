using iText.Kernel.Pdf.Canvas.Parser;
using MS.Lib.Pdf.Abstractions;
using System.Text;

namespace MS.Lib.Pdf.iText
{
    public class PdfHandler : IPdfHandler
    {
        private readonly iTextHelper _helper;

        public PdfHandler(iTextHelper helper)
        {
            _helper = helper;
        }

        public int GetPages(string filePath)
        {
            using var doc = _helper.OpenRead(filePath);
            return doc.GetNumberOfPages();
        }

        public string GetFullText(string filePath)
        {
            var sb = new StringBuilder();
            using var doc = _helper.OpenRead(filePath);
            var font = doc.GetDefaultFont();
            var number = doc.GetNumberOfPages();
            for (int i = 1; i <= number; i++)
            {
                var page = doc.GetPage(i);

                sb.Append(PdfTextExtractor.GetTextFromPage(page));
            }

            return sb.ToString();
        }
    }
}
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace PdfDemo.Models
{
    public class PdfWorker
    {
        private readonly Article _article;
        private readonly string _view;

        public PdfWorker(Article article, string view)
        {
            _article = article;
            _view = view;
        }

        public ActionResult GeneratePdf()
        {
            var template = GetTemplate();
            var html = Engine.Razor.RunCompile(template, Guid.NewGuid().ToString(), typeof(Article), _article);

            using (var ms = new MemoryStream())
            {
                using (var pdfDoc = new Document())
                {
                    using (var writer = PdfWriter.GetInstance(pdfDoc, ms))
                    {
                        pdfDoc.Open();

                        try
                        {
                            using (var htmlStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                            {
                                XMLWorkerHelper.GetInstance()
                                    .ParseXHtml(writer, pdfDoc, htmlStream, System.Text.Encoding.UTF8);
                            }
                        }
                        finally
                        {
                            pdfDoc.Close();
                        }

                        return new FileContentResult(ms.ToArray(), "application/pdf");
                    }
                }
            }
        }

        private string GetTemplate()
        {
            var viewPath = HttpContext.Current.Server.MapPath(_view);
            return File.ReadAllText(viewPath);
        }
    }
}
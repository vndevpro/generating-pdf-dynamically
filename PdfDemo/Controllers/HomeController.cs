using System.Web.Mvc;

namespace PdfDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult DownloadPdf(int id)
        //{
        //    var article = GetArticle(id);
        //    var worker = new PdfWorker(article, "~/Views/Shared/_ArticlePdf.cshtml");
        //    return worker.GeneratePdf();
        //}

        //private Article GetArticle(int id)
        //{
        //    return new Article
        //    {
        //        Id = id,
        //        Title = "This is a demo article",
        //        Details = "Detail is here. <b>Bold contents</b>"
        //    };
        //}
    }
}

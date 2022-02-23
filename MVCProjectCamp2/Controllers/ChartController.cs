using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using MVCProjectCamp2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    [Authorize]
    public class ChartController : Controller
    {
        private readonly Context db = new Context();

        public ActionResult CardList()
        {
            ViewBag.count = db.Categories.Count(x => x.Status == true);
            ViewBag.acontains = db.Writers.Count(x => x.WriterName.Contains("a") && x.Status);
            byte deger = db.Headings.GroupBy(x => x.CategoryID).Select(x => new { Category = x.Key, Sayısı = x.Count() }).OrderByDescending(x => x.Sayısı).Select(x => x.Category).FirstOrDefault();
            ViewBag.max = db.Categories.Where(x => x.CategoryID == deger).Select(x => x.CategoryName).FirstOrDefault()?.ToString();
            ViewBag.trueandfalse = db.Categories.Count(x => x.Status == true) - db.Categories.Count(x => x.Status == false);

            ViewBag.name = db.Categories.FirstOrDefault(x => x.Status == true).CategoryName.ToString();
            ViewBag.software = db.Headings.Count(x => x.Status == true && x.CategoryID == db.Categories.Where(y => y.CategoryID == deger).Select(y => y.CategoryID).FirstOrDefault()).ToString();
            return View();
        }

        public ActionResult GoogleWriter()
        {
            return View();
        }
        public ActionResult GoogleWriterContent()
        {
            return Json(ContentWriter(), JsonRequestBehavior.AllowGet);
        }
        public List<Models.WriterClass> ContentWriter()
        {
            List<Models.WriterClass> ct = new List<WriterClass>();
            foreach (var item in db.Writers.Where(x => x.Status == true).ToList())
            {
                ct.Add(new WriterClass()
                {
                    WriterName = item.WriterName,
                    WriterCount = (short)db.Contents.Count(x => x.WriterID == item.WriterID)
                });
            }
            return ct;
        }
        public ActionResult GoogleChart()
        {
            return View();
        }
        public ActionResult GoogleContent()
        {
            return View();
        }
        public ActionResult GoogleWrite()
        {
            return View();
        }
        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ContentChart()
        {
            return Json(BlogContent(), JsonRequestBehavior.AllowGet);
        }
        public List<Models.ContentClass> BlogContent()
        {
            List<ContentClass> ct = new List<ContentClass>();
            foreach (Heading item in db.Headings.Where(x => x.Status == true).ToList())
            {
                ct.Add(new ContentClass()
                {
                    ContentName = item.HeadingName,
                    ContentCount = (short)db.Contents.Count(x => x.HeadingID == item.HeadingID)
                });
            }
            return (ct);
        }
        public List<Models.WriterClass> WriterList()
        {
            List<WriterClass> ct = new List<WriterClass>();
            foreach (Writer item in db.Writers.Where(x => x.Status == true).ToList())
            {
                ct.Add(new WriterClass()
                {
                    WriterName = item.WriterName,
                    WriterCount = ((short)db.Headings.Count(x => x.WriterID == item.WriterID))
                });
            }
            return (ct);
        }
        public List<Models.CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            foreach (Category item in db.Categories.Where(x => x.Status == true).ToList())
            {
                categoryClasses.Add(new CategoryClass()
                {
                    CategoryName = item.CategoryName,
                    CategoryCount = (short)db.Headings.Count(x => x.CategoryID == item.CategoryID)
                });
            }
            return (categoryClasses);
        }
    }
}
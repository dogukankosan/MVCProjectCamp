using BussinesLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    [Authorize]
    public class AdminContentController : Controller
    {
        private readonly ContentManager mng = new ContentManager(new EFContentDAL());
        private readonly Context db = new Context();

        public ActionResult HeadingByContent(short id, byte page = 1)
        {
            var deger = mng.WhereList(x => x.HeadingID == id).ToPagedList(page, 6);
            ViewBag.dgr = deger.Select(x => x.Heading.HeadingName).FirstOrDefault();
            ViewBag.count = deger.Count;
            return View(deger);
        }
        public ActionResult GetAllContent(string source, byte page = 1)
        {
            IPagedList<Content> deger = null;
            if (!(string.IsNullOrEmpty(source)))
                deger = mng.GetFindList(source).ToPagedList(page, 6);
            else
                deger = mng.GetList().ToPagedList(page, 6);
            return View(deger);
        }
        public ActionResult StatusChanged(short id, bool status)
        {
            status = status ? status = false : status = true;
            var deger = db.Contents.FirstOrDefault(x => x.ContentID == id);
            deger.Status = status;
            db.SaveChanges();
            return RedirectToAction("HeadingList", "AdminHeading");
        }
    }
}
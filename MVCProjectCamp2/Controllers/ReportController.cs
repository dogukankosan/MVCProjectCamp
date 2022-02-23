using BussinesLogicLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    [Authorize(Roles = "B")]
    public class ReportController : Controller
    {
        private readonly HeadingManager db = new HeadingManager(new EFHeadingDAL());
        private readonly WriterManager wr = new WriterManager(new EFWriterDAL());
        private readonly CategoryManager ct = new CategoryManager(new EFCategoryDAL());
        public ActionResult HeadingList()
        {
            List<Heading> deger = db.GetList();
            return View(deger);
        }
        public ActionResult WriterList()
        {
            List<Writer> deger = wr.GetList();
            return View(deger);
        }
        public ActionResult CategoryList()
        {
            List<Category> deger = ct.GetList();
            return View(deger);
        }
    }
}
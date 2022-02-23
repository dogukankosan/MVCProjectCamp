using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly ContactManager db = new ContactManager(new EFContactDAL());
        private readonly MessageManager mng = new MessageManager(new EFMessageDAL());
        private readonly Context ct = new Context();
        private readonly ContactValidation Validation = new ContactValidation();
        [Authorize]
        public ActionResult List()
        {
            ViewBag.concat = TempData["concat"] as string;
            List<Contact> deger = db.List().OrderByDescending(x => x.ContactID).ToList();
            return View(deger);
        }
        [Authorize]
        public ActionResult GetList(short id)
        {
            ct.Database.ExecuteSqlCommand("update Contacts set [Read]=1 where ContactID=" + id + "");
            ct.SaveChanges();
            Contact deger = db.GetByID(id);
            return View(deger);
        }
        [Authorize]
        public PartialViewResult SideBar()
        {
            string user = (string)Session["UserNameAdmin"];
            Admin mail = ct.Admins.FirstOrDefault(x => x.UserNameAdmin == user);
            ViewBag.msg = db.List().Count.ToString();
            ViewBag.send = mng.WhereList(x => x.Sender == mail.Mail && x.Status == true).Count.ToString();
            ViewBag.inbox = mng.WhereList(x => x.Receiver == mail.Mail && x.Status == true).Count.ToString();
            ViewBag.delete = mng.WhereList(x => x.Receiver == mail.Mail ^ x.Sender == mail.Mail && x.Status == false).Count.ToString();
            return PartialView();
        }
        [Authorize]
        public ActionResult Delete(short id)
        {
            Contact deger = db.GetByID(id);
            db.Delete(deger);
            TempData["concat"] = "concat";
            return RedirectToAction("List");
        }
    }
}
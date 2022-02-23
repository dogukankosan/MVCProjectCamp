using System.Collections.Generic;
using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using MVCProjectCamp2.Hash;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    [Authorize(Roles = "B")]
    public class AdminWriterController : Controller
    {
        private readonly WriterManager mng = new WriterManager(new EFWriterDAL());
        private readonly WriterValidation validation = new WriterValidation();
        private readonly Context db = new Context();
     
        public ActionResult WriterList(byte page = 1)
        {
            ViewBag.add = TempData["add"];
            ViewBag.update = TempData["update"];
            IPagedList<Writer> deger = mng.GetList().ToPagedList(page, 6);
            return View(deger);
        }
        [HttpGet]
        [Authorize]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [Authorize]
        public ActionResult StatusChanged(Writer p, byte id, bool status)
        {
            status = status ? status = false : status = true;
            var deger = db.Writers.FirstOrDefault(x => x.WriterID == id);
            deger.Status = status;
            p = deger;
            db.Database.ExecuteSqlCommand("update Headings set Status='" + status + "' where WriterID=" + id + "");
            db.SaveChanges();
            db.Database.ExecuteSqlCommand("update Contents set Status='" + status + "' where WriterID=" + id + "");
            db.SaveChanges();
            return RedirectToAction("WriterList");
        }
        [HttpPost]
        [Authorize]
        public ActionResult WriterAdd(Writer p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                p.Password = Encryption.Enc(p.Password);
                p.Status = true;
                mng.Add(p);
                TempData["add"] = "add";
                return RedirectToAction("WriterList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        [Authorize]
        public ActionResult WriterUpdate(short id)
        {
            var deger = mng.GetById(id);
            return View(deger);
        }
        [HttpPost]
        [Authorize]
        public ActionResult WriterUpdate(Writer p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                Writer deger = mng.GetById(p.WriterID);
                deger.Password = deger.Password == p.Password
                    ? p.Password
                    : Encryption.Enc(p.Password);
                deger.Contents = p.Contents;
                deger.WriterTitle = p.WriterTitle;
                deger.WriterSurName = p.WriterSurName;
                deger.WriterName = p.WriterName;
                deger.WriterAbout = p.WriterAbout;
                deger.Mail = p.Mail;
                deger.Image = p.Image;
                mng.Update(deger);
                TempData["update"] = "update";
                return RedirectToAction("WriterList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public ActionResult GetByWriterHeading(short id)
        {
            List<Heading> deger=db.Headings.Where(x => x.WriterID == id).OrderByDescending(x => x.HeadingName).ToList();
            return View(deger);
        }
    }
}
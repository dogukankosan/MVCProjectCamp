using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCProjectCamp2.Hash;

namespace MVCProjectCamp2.Controllers
{
    public class UserWriterController : Controller
    {
        private readonly HeadingManager db = new HeadingManager(new EFHeadingDAL());
        private readonly ContentManager ct = new ContentManager(new EFContentDAL());
        private readonly Context mng = new Context();
        private readonly HeadingValidation validation = new HeadingValidation();
        private readonly WriterValidation writerValidation = new WriterValidation();
        private readonly WriterManager writerManager = new WriterManager(new EFWriterDAL());
        public ActionResult List()
        {
            ViewBag.message = TempData["message"] as string;
            string mail = (string)Session["WriterMail"];
            Writer deger = mng.Writers.FirstOrDefault(x => x.Mail == mail);
            return View(deger);
        }
        [HttpGet]
        public ActionResult Update(short id)
        {
            Writer deger = mng.Writers.FirstOrDefault(x => x.WriterID == id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Writer p)
        {
            ValidationResult result = writerValidation.Validate(p);
            if (result.IsValid)
            {
                Writer deger = writerManager.GetById(p.WriterID);
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
                writerManager.Update(deger);
                TempData["message"] = "mesaj";
                return RedirectToAction("List");
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
        public ActionResult HeadingContent(short id, byte page = 1)
        {
            TempData["add"] = null;
            TempData["update"] = null;
            string mail = (string)Session["WriterMail"];
            Writer user = mng.Writers.FirstOrDefault(x => x.Mail == mail);
            IPagedList<EntitiyLayer.Concrete.Content> deger = ct.WhereList(x => x.HeadingID == id && x.Writer.Status==true).ToPagedList(page, 6);
            ViewBag.dgr = deger.Select(x => x.Heading.HeadingName).FirstOrDefault();
            ViewBag.count = deger.Count;
            return View(deger);
        }
        public ActionResult MyHeading()
        {
            ViewBag.add = TempData["add"] as string;
            ViewBag.message = TempData["update"] as string;
            string mail = (string)Session["WriterMail"];
            Writer user = mng.Writers.FirstOrDefault(x => x.Mail == mail);
            List<Heading> deger = db.WhereList(x => x.WriterID == user.WriterID);
            return View(deger);
        }
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> listcate = (from x in mng.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.CategoryID.ToString(),
                                                 Text = x.CategoryName
                                             }).ToList();
            ViewBag.listcate = listcate;
            return View();
        }
        [HttpPost]
        public ActionResult HeadingAdd(Heading p)
        {
            p.Status = true;
            string mail = (string)Session["WriterMail"];
            Writer user = mng.Writers.FirstOrDefault(x => x.Mail == mail);
            p.WriterID = user.WriterID;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                db.Add(p);
                TempData["add"] = "add";
                return RedirectToAction("MyHeading");
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
        public ActionResult HeadingUpdate(short id)
        {
            List<SelectListItem> listcate = (from x in mng.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.CategoryID.ToString(),
                                                 Text = x.CategoryName
                                             }).ToList();
            ViewBag.listcate = listcate;
            Heading deger = mng.Headings.FirstOrDefault(x => x.HeadingID == id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult HeadingUpdate(Heading p)
        {
            string mail = (string)Session["WriterMail"];
            Writer user = mng.Writers.FirstOrDefault(x => x.Mail == mail);
            p.WriterID = user.WriterID;
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                db.Update(p);
                TempData["update"] = "update";
                return RedirectToAction("MyHeading");
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
        public ActionResult StatusChanged(short id)
        {
            var deger = db.GetById(id);
            deger.Status = !deger.Status;
            db.Update(deger);
            mng.Database.ExecuteSqlCommand("update Contents set Status='" + deger.Status + "' where HeadingID=" + id + "");
            mng.SaveChanges();
            return RedirectToAction("MyHeading");
        }
    }
}
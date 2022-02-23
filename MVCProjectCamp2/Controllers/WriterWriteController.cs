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

namespace MVCProjectCamp2.Controllers
{
    public class WriterWriteController : Controller
    {
        private readonly ContentManager db = new ContentManager(new EFContentDAL());
        private readonly HeadingManager ct = new HeadingManager(new EFHeadingDAL());
        private readonly ContentValidation validation = new ContentValidation();
        private readonly Context mng = new Context();
        public ActionResult List(byte page = 1)
        {
            ViewBag.message = TempData["message"] as string;
            string mail = (string)Session["WriterMail"];
            Writer user = mng.Writers.FirstOrDefault(x => x.Mail == mail);
            var deger = db.WhereList(x => x.WriterID == user.WriterID).ToPagedList(page, 6);
            ViewBag.dgr = deger.Select(x => x.Heading.HeadingName).FirstOrDefault();
            return View(deger);
        }
        public ActionResult StatusChanged(Content p, byte id, bool status)
        {
            status = status ? status = false : status = true;
            var deger = mng.Contents.FirstOrDefault(x => x.ContentID == id);
            deger.Status = status;
            p = deger;
            mng.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Update(short id)
        {
            Content deger = mng.Contents.FirstOrDefault(x => x.ContentID == id);
            return View(deger);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Content p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                db.Update(p);
                TempData["message"] = "update";
                return RedirectToAction("List");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("List");
            }
        }

        public ActionResult AllList()
        {
            ViewBag.message = TempData["message"] as string;
            List<Heading> deger = ct.WhereList(x => x.Status == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult HeadingContent(short id)
        {
            TempData["headingid"] = id;
            Heading deger = ct.GetById(id);
            ViewBag.dgr = deger.HeadingName.ToString();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HeadingContent(Content p)
        {
            p.HeadingID = (short)TempData["headingid"];
            p.Date = DateTime.Now;
            string user = (string)Session["WriterMail"];
            Writer mail = mng.Writers.FirstOrDefault(x => x.Mail == user);
            p.WriterID = mail.WriterID;
            p.Status = true;
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                db.Add(p);
                TempData["message"] = "add";
                return RedirectToAction("AllList");
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
    }
}
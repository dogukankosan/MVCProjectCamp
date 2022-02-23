using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using MVCProjectCamp2.Hash;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ContentManager db = new ContentManager(new EFContentDAL());
        private readonly ContactValidation validation = new ContactValidation();
        private readonly ContactManager mng = new ContactManager(new EFContactDAL());
        private readonly GalleryManager dl = new GalleryManager(new EFGalleryDAL());
        private readonly WriterValidation wrt = new WriterValidation();
        private readonly WriterManager wrtmng = new WriterManager(new EFWriterDAL());

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetBy(short id, byte page = 1)
        {
            IPagedList<Content> deger = db.WhereList(x => x.HeadingID == id && x.Status == true).ToPagedList(page, 6);
            ViewBag.dgr = deger.Count != 0 ? deger.Select(x => x.Heading.HeadingName).FirstOrDefault().ToString() : null;
            ViewBag.count = deger.Count;
            return View(deger);
        }
        [HttpGet]
        public PartialViewResult RegisterWriter()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult RegisterWriter(Writer p)
        {
            p.Status = false;
            ValidationResult result = wrt.Validate(p);
            if (result.IsValid)
            {
                p.Password = Encryption.Enc(p.Password);
                wrtmng.Add(p);
                TempData["writer"] = (string)"wr";
                return RedirectToAction("Vitrin", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return PartialView();
            }
        }

        public ActionResult Contact(Contact p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                p.Date = DateTime.Now;
                mng.Add(p);
                TempData["message"] = (string)"ba";
                return RedirectToAction("Vitrin");
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

        public PartialViewResult Side()
        {
            List<Gallery> deger = dl.GetList();
            return PartialView(deger);
        }
        public ActionResult Vitrin()
        {
            ViewBag.message = TempData["message"] as string;
            ViewBag.writer = TempData["writer"] as string;
            return View();
        }
    }
}
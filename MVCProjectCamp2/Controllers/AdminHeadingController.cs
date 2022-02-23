using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    [Authorize]
    public class AdminHeadingController : Controller
    {
        private readonly HeadingManager mng = new HeadingManager(new EFHeadingDAL());
        private readonly Context db = new Context();
        private readonly HeadingValidation validation = new HeadingValidation();
        public ActionResult HeadingList()
        {
            ViewBag.update = TempData["update"];
            ViewBag.delete = TempData["delete"];
            ViewBag.add = TempData["add"];
            var deger = mng.GetList();
            return View(deger);
        }
        public ActionResult statusChanged(short id,bool status)
        {
            status = status ? status = false : status = true;
            var deger = db.Headings.FirstOrDefault(x => x.HeadingID == id);
            deger.Status = status;
            db.Database.ExecuteSqlCommand("update Contents set Status='" + deger.Status + "' where HeadingID=" + id + "");
            db.SaveChanges();
            return RedirectToAction("HeadingList");
        }
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> listcate = (from x in db.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.CategoryID.ToString(),
                                                 Text = x.CategoryName
                                             }).ToList();
            List<SelectListItem> listwrit = (from x in db.Writers.Where(x=>x.Status==true).ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.WriterID.ToString(),
                                                 Text = x.WriterName + " " + x.WriterSurName
                                             }).ToList();
            ViewBag.listwrit = listwrit;
            ViewBag.listcate = listcate;
            return View();
        }
        [HttpPost]
        public ActionResult HeadingAdd(Heading p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                mng.Add(p);
                TempData["add"] = "add";
                return RedirectToAction("HeadingList");
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
        public ActionResult Delete(short id)
        {
            var deger = mng.GetById(id);
            mng.Delete(deger);
            TempData["delete"] = "delete";
            return RedirectToAction("HeadingList");
        }
        [HttpGet]
        public ActionResult HeadingUpdate(short id)
        {
            List<SelectListItem> listcate = (from x in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.CategoryID.ToString(),
                                                 Text = x.CategoryName
                                             }).ToList();
            List<SelectListItem> listwrit = (from x in db.Writers.ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.WriterID.ToString(),
                                                 Text = x.WriterName + " " + x.WriterSurName
                                             }).ToList();
            ViewBag.listwrit = listwrit;
            ViewBag.listcate = listcate;
            var deger = mng.GetById(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult HeadingUpdate(Heading p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                var deger = mng.GetById(p.HeadingID);
                deger.Status = p.Status;
                deger.Date = p.Date;
                deger.CategoryID = p.CategoryID;
                deger.WriterID = p.WriterID;
                deger.HeadingName = p.HeadingName;
                mng.Update(deger);
                TempData["update"] = "update";
                return RedirectToAction("HeadingList");
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
using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    [Authorize(Roles = "B")]
    public class AdminAboutController : Controller
    {
        private readonly AboutManager mng = new AboutManager(new EFAboutDAL());
        private readonly AboutValidation validation = new AboutValidation();
    
        public ActionResult List()
        {
            ViewBag.update = TempData["update"];
            ViewBag.delete = TempData["delete"];
            ViewBag.add = TempData["add"];
            var deger = mng.GetList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult AboutUpdate(byte id)
        {
            var deger = mng.GetById(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult AboutUpdate(About p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                mng.Update(p);
                TempData["update"] = "update";
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
        public ActionResult Delete(byte id)
        {
            var deger = mng.GetById(id);
            mng.Delete(deger);
            TempData["delete"] = "delete";
            return RedirectToAction("List");
        }
        public PartialViewResult AboutAdd()
        {
            return PartialView();
        }
        public ActionResult AboutAddpost(About p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                mng.Add(p);
                TempData["add"] = "add";
                return RedirectToAction("List");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("AboutAdd");
            }
        }
    }
}
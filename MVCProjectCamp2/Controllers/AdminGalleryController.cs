using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    [Authorize]
    public class AdminGalleryController : Controller
    {
        private readonly GalleryManager db = new GalleryManager(new EFGalleryDAL());
        private readonly GalleryValidation Validation = new GalleryValidation();

        public ActionResult List()
        {
            ViewBag.update = TempData["update"];
            List<Gallery> deger = db.GetList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult Update(byte id)
        {
            Gallery d = db.GetByID(id);
            return View(d);
        }

        [HttpPost]
        public ActionResult Update(Gallery p)
        {
            ValidationResult result = Validation.Validate(p);
            if (result.IsValid)
            {
                db.Update(p);
                TempData["update"] = "update";
                return RedirectToAction("List");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorCode);
                }
            }
            return View();
        }
    }
}
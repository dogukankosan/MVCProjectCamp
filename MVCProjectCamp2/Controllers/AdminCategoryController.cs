using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace MVCProjectCamp2.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly CategoryManager mng = new CategoryManager(new EFCategoryDAL());
        private readonly Context db = new Context();
        private readonly CategoryValidation validation = new CategoryValidation();
        [Authorize]
        public ActionResult CategoryList()
        {
            ViewBag.update = TempData["update"];
            ViewBag.delete = TempData["delete"];
            ViewBag.add = TempData["add"];
            var deger = mng.GetList();
            return View(deger);
        }
        [HttpGet]
        [Authorize]
        public ActionResult CategoryUpdate(byte id)
        {
            var deger = mng.GetById(id);
            return View(deger);
        }
        [HttpPost]
        [Authorize]
        public ActionResult CategoryUpdate(Category p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                mng.Update(p);
                TempData["update"]="update";
                return RedirectToAction("CategoryList");
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
        [Authorize]
        public ActionResult Delete(byte id)
        {
            var deger = mng.GetById(id);
            mng.Delete(deger);
            TempData["delete"]="delete";
            return RedirectToAction("CategoryList");
        }
        [Authorize]
        public ActionResult StatusChanged(Category p, byte id, bool status, string message)
        {
            status = status ? status = false : status = true;
            var deger = db.Categories.FirstOrDefault(x => x.CategoryID == id);
            deger.Status = status;
            p = deger;
            db.Database.ExecuteSqlCommand("update Headings set Status='" + status + "' where CategoryID=" + id + "");
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        [Authorize]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [Authorize]
        public ActionResult CategoryAdd(Category p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                mng.Add(p);
                TempData["add"] = "add";
                return RedirectToAction("CategoryList");
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
using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using MVCProjectCamp2.Hash;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCProjectCamp2.Controllers
{
    public class UserSettingsController : Controller
    {
        private readonly AdminManager mng = new AdminManager(new EFAdminDAL());
        private readonly AdminValidation validation = new AdminValidation();
        private readonly Context db = new Context();
        [Authorize(Roles = "B")]
        public ActionResult List()
        {
            ViewBag.update = TempData["update"];
            ViewBag.add = TempData["add"];
            List<Admin> deger = mng.GetList();
            return View(deger);
        }
        [HttpGet]
        [Authorize(Roles = "B")]
        public ActionResult Update(byte id)
        {
            Admin deger = mng.GetByID(id);
            return View(deger);
        }
        [HttpPost]
        [Authorize(Roles = "B")]
        public ActionResult Update(Admin p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                Admin deger = mng.GetByID(p.ID);
                deger.PasswordAdmin = deger.PasswordAdmin == p.PasswordAdmin
                    ? p.PasswordAdmin
                    : Encryption.Enc(p.PasswordAdmin);
                deger.AdminRole = p.AdminRole;
                deger.UserNameAdmin = p.UserNameAdmin;
                deger.Mail = p.Mail;
                deger.Image = p.Image;
                mng.Update(deger);
                TempData["update"] = "update";
                return RedirectToAction("List");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Authorize(Roles = "B")]
        public PartialViewResult UserAdd()
        {
            return PartialView();
        }
        [Authorize(Roles = "B")]
        public ActionResult Add(Admin p)
        {
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                p.PasswordAdmin = Encryption.Enc(p.PasswordAdmin);
                p.Status = true;
                mng.Add(p);
                TempData["add"]="add";
                return RedirectToAction("List");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Authorize(Roles = "B")]
        public ActionResult StatusChanged(Admin p, byte id, bool status)
        {
            status = status ? status = false : status = true;
            var deger = db.Admins.FirstOrDefault(x => x.ID == id);
            deger.Status = status;
            mng.Update(deger);
            return RedirectToAction("List");
        }
    }
}
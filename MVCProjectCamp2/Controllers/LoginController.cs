using BussinesLogicLayer.Concrete;
using BussinesLogicLayer.Validation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using MVCProjectCamp2.Hash;
using MVCProjectCamp2.reCAPTCHA;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjectCamp2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly AdminManager mng = new AdminManager(new EFAdminDAL());
        private readonly AdminValidation Validation = new AdminValidation();
        [HttpGet]
        public ActionResult List()
        {
            ViewBag.message = TempData["message"] as string;
            ViewBag.captch = TempData["captch"] as string;
            return View();
        }
        [HttpPost]
        public ActionResult List(Admin p)
        {
            string encoderesponse = Request.Form["g-Recaptcha-Response"];
            bool iscaptcha = GoogleCAPTCHA.Validate(encoderesponse);
            Context deger = new Context();
            p.PasswordAdmin = Encryption.Enc(p.PasswordAdmin);
            Admin deger1 = deger.Admins.FirstOrDefault(x => x.PasswordAdmin == p.PasswordAdmin & x.Status == true & x.UserNameAdmin == p.UserNameAdmin);
            string error = deger1 != null ? p.AdminRole = deger1.AdminRole : null;
            string errorpi = deger1 != null ? p.Image = deger1.Image : null;
            string errormail = deger1 != null ? p.Mail = deger1.Mail : null;
            ValidationResult result = Validation.Validate(p);
            if (iscaptcha)
            {
                if (result.IsValid)
                {
                    if (deger1 != null)
                    {
                        FormsAuthentication.SetAuthCookie(deger1.UserNameAdmin, false);
                        Session["UserNameAdmin"] = deger1.UserNameAdmin;
                        return RedirectToAction("CategoryList", "AdminCategory");
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                TempData["message"] = (string)"hat";
                return RedirectToAction("List");
            }
            else
            {
                TempData["captch"] = (string)"hat";
                return RedirectToAction("List");
            }
        }
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","WriterLogin");
        }
    }
}
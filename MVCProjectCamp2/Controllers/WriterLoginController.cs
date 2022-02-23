using BussinesLogicLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using MVCProjectCamp2.Hash;
using MVCProjectCamp2.reCAPTCHA;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjectCamp2.Controllers
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {

        private readonly WriterLoginManager mng = new WriterLoginManager(new EFWriterDAL());
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.message = TempData["message"] as string;
            ViewBag.captch=TempData["captch"] as string;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Writer p)
        {
            string encoderesponse = Request.Form["g-Recaptcha-Response"];
            bool iscaptcha = GoogleCAPTCHA.Validate(encoderesponse);
            p.Password = Encryption.Enc(p.Password);
            Writer deger1 = mng.GetByID(p.Mail, p.Password);
            if (iscaptcha)
            {
                if (deger1 != null && deger1.Status==true)
                {
                    FormsAuthentication.SetAuthCookie(deger1.Mail, false);
                    Session["WriterMail"] = deger1.Mail;

                    return RedirectToAction("List", "UserWriter");
                }
                else
                    TempData["message"] = (string)"hat";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["captch"] = (string) "af";
                return RedirectToAction("Login");
            }
        }
    }
}
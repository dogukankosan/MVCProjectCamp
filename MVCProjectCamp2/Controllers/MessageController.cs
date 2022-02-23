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
    public class MessageController : Controller
    {
        private readonly MessageManager db = new MessageManager(new EFMessageDAL());
        private readonly MessageValidation validation = new MessageValidation();
        private readonly Context mng = new Context();

        public ActionResult List()
        {
            string user = (string)Session["UserNameAdmin"];
            Admin mail = mng.Admins.FirstOrDefault(x => x.UserNameAdmin == user);
            List<Message> deger = db.WhereList(x => x.Receiver == mail.Mail && x.Status == true).OrderByDescending(x => x.ID).ToList();
            return View(deger);
        }

        public ActionResult GetBySendMail(short id)
        {
            Message deger = db.GetByID(id);
            Writer writer=mng.Writers.FirstOrDefault(x => x.Mail == deger.Receiver);
            ViewBag.image=writer.Image;
            ViewBag.name=string.Concat(writer.WriterName," ",writer.WriterSurName);
            return View(deger);
        }
        public ActionResult Delete(short id)
        {
            Message deger = db.GetByID(id);
            deger.Status = false;
            db.Update(deger);
            TempData["delete"] = "delete";
            return RedirectToAction("SendMail");
        }
        public ActionResult StatusChanged(short id)
        {
            Message deger = db.GetByID(id);
            deger.Status = true;
            db.Update(deger);
            TempData["status"] = "status";
            return RedirectToAction("SendMail");
        }
        public ActionResult SendMail()
        {
            ViewBag.delete = TempData["delete"] as string;
            ViewBag.add = TempData["add"] as string;
            ViewBag.status = TempData["status"] as string;
            string user = (string)Session["UserNameAdmin"];
            Admin mail = mng.Admins.FirstOrDefault(x => x.UserNameAdmin == user);
            List<Message> deger = db.WhereList(x => x.Sender == mail.Mail && x.Status == true).OrderByDescending(x => x.ID).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            string user = (string)Session["UserNameAdmin"];
            EntitiyLayer.Concrete.Message me = new Message();
            List<SelectListItem> deger = (from x in mng.Writers.Where(x => x.Status == true &&x.Mail!=user).OrderBy(x => x.WriterName).ToList()
                select new SelectListItem
                {
                    Value = me.Receiver,
                    Text = x.Mail
                }).ToList();
            ViewBag.writer = deger;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMessage(Message p)
        {
            string session = (string)Session["UserNameAdmin"];
            Admin mail = mng.Admins.FirstOrDefault(x => x.UserNameAdmin == session);
            p.MessageDate = DateTime.Now;
            p.Status = true;
            p.Sender = mail.Mail;
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                db.Add(p);
                TempData["add"] = "add";
                return RedirectToAction("SendMail");
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
        public ActionResult GetByID(short id)
        {
            mng.Database.ExecuteSqlCommand("update Messages set ReadStatus=1 where ID=" + id + "");
            mng.SaveChanges();
            Message deger = db.GetByID(id);
            Writer writer = mng.Writers.FirstOrDefault(x => x.Mail == deger.Sender);
            ViewBag.image = writer.Image;
            ViewBag.name = string.Concat(writer.WriterName, " ", writer.WriterSurName);
            return View(deger);
        }
        public ActionResult DeleteList()
        {
            string user = (string)Session["UserNameAdmin"];
            Admin mail = mng.Admins.FirstOrDefault(x => x.UserNameAdmin == user);
            List<Message> deger = db.WhereList(x => (x.Receiver == mail.Mail ^ x.Sender == mail.Mail) && x.Status == false).OrderByDescending(x=>x.ID).ToList();
            return View(deger);
        }

        public ActionResult DeleteByID(short id)
        {
            Message deger = db.GetByID(id);
            Writer mail = mng.Writers.FirstOrDefault(x => x.Mail == deger.Receiver);
            ViewBag.image = mail.Image;
            ViewBag.name = string.Concat(mail.WriterName, " ", mail.WriterSurName);
            return View(deger);
        }
    }
}
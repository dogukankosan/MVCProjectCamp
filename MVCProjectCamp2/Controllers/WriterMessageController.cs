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
    public class WriterMessageController : Controller
    {
        private readonly MessageManager mng = new MessageManager(new EFMessageDAL());
        private readonly MessageValidation validation = new MessageValidation();
        private readonly Context db = new Context();

        public ActionResult List()
        {
            string mail = (string)Session["WriterMail"];
            List<Message> deger = mng.WhereList(x => x.Receiver == mail && x.Status == true).OrderByDescending(x => x.ID).ToList();
            return View(deger);
        }

        public ActionResult GetByInbox(short id)
        {
            db.Database.ExecuteSqlCommand("update Messages set ReadStatus=1 where ID=" + id + "");
            db.SaveChanges();
            Message deger = mng.GetByID(id);
           Writer writer = db.Writers.FirstOrDefault(x => x.Mail == deger.Sender);
           ViewBag.image=writer.Image;
           ViewBag.name = string.Concat(writer.WriterName, " ", writer.WriterSurName);
            return View(deger);
        }
        public ActionResult GetBySend(short id)
        {
            Message deger = mng.GetByID(id);
            Writer writer = db.Writers.FirstOrDefault(x => x.Mail == deger.Receiver);
            ViewBag.image = writer.Image;
            ViewBag.name = string.Concat(writer.WriterName, " ", writer.WriterSurName);
            return View(deger);
        }
        public ActionResult SendMail()
        {
            ViewBag.delete = TempData["delete"] as string;
            ViewBag.add = TempData["add"] as string;
            ViewBag.status = TempData["status"] as string;
            string mail = (string)Session["WriterMail"];
            List<Message> deger = mng.WhereList(x => x.Sender == mail && x.Status == true).OrderByDescending(x => x.ID).ToList();
            return View(deger);
        }
        public PartialViewResult SideBard()
        {
            string user = (string)Session["WriterMail"];
            Writer mail = db.Writers.FirstOrDefault(x => x.Mail == user);
            ViewBag.send = mng.WhereList(x => x.Sender == mail.Mail && x.Status == true).Count.ToString();
            ViewBag.inbox = mng.WhereList(x => x.Receiver == mail.Mail && x.Status == true).Count.ToString();
            ViewBag.delete = mng.WhereList(x => x.Receiver == mail.Mail ^ x.Sender == mail.Mail && x.Status == false).Count.ToString();
            return PartialView();
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            string mail = (string)Session["WriterMail"];
            EntitiyLayer.Concrete.Message me = new Message();
            List<SelectListItem> deger = (from x in db.Writers.Where(x => x.Status == true & x.Mail != mail).OrderBy(x=>x.WriterName).ToList()
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
        public ActionResult NewMessage(Message p)
        {
            string mail = (string)Session["WriterMail"];
            p.MessageDate = DateTime.Now;
            p.Sender = mail;
            p.Status = true;
            ValidationResult result = validation.Validate(p);
            if (result.IsValid)
            {
                mng.Add(p);
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
        public ActionResult Delete(short id)
        {
            Message deger = mng.GetByID(id);
            deger.Status = false;
            mng.Update(deger);
            TempData["delete"] = "delete";
            return RedirectToAction("SendMail");
        }
        public ActionResult StatusChanged(short id)
        {
            Message deger = mng.GetByID(id);
            deger.Status = true;
            mng.Update(deger);
            TempData["status"] = "status";
            return RedirectToAction("SendMail");
        }
        public ActionResult DeleteList()
        {
            string user = (string)Session["WriterMail"];
            Writer mail = db.Writers.FirstOrDefault(x => x.Mail == user);
            List<Message> deger = mng.WhereList(x => (x.Receiver == mail.Mail ^ x.Sender == mail.Mail) && x.Status == false).OrderByDescending(x => x.ID).ToList();
            return View(deger);
        }

        public ActionResult DeleteByID(short id)
        {
            Message deger = mng.GetByID(id);
            Writer mail = db.Writers.FirstOrDefault(x => x.Mail == deger.Receiver);
            ViewBag.image = mail.Image;
            ViewBag.name = string.Concat(mail.WriterName, " ", mail.WriterSurName);
            return View(deger);
        }
    }
}
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class DefaultContactController : Controller
    { LearnerContext context = new LearnerContext();
        // GET: DefaultContact
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ContactInfo()
        {
            var values = context.Contacts.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
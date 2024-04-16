using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class FAQController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: FAQ
        public ActionResult Index()
        {
            var values = context.FAQs.ToList();
            return View(values);
        }

        public ActionResult DeleteFAQ(int id)
        {
            var values = context.FAQs.Find(id);
            context.FAQs.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddFAQ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFAQ(FAQ faq)
        {
            context.FAQs.Add(faq);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFAQ(int id)
        {
            var values = context.FAQs.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFAQ(FAQ faq)
        {
            var values = context.FAQs.Find(faq.FAQId);
            values.Answer = faq.Answer;
            values.ImageUrl = faq.ImageUrl;
            values.Question = faq.Question;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
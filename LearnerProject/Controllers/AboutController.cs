using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AboutController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: About
        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = context.Abouts.Find(id);
            context.Abouts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = context.Abouts.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var values = context.Abouts.Find(about.AboutId);
            values.ImageUrl = about.ImageUrl;
            values.Title = about.Title;
            values.Description = about.Description;
            values.Item1 = about.Item1;
            values.Item2 = about.Item2;
            values.Item3 = about.Item3;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
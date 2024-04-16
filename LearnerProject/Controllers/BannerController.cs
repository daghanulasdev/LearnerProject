using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class BannerController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Banner
        public ActionResult Index()
        {
            var values = context.Banners.ToList();
            return View(values);
        }
        public ActionResult DeleteBanner(int id)
        {
            var values = context.Banners.Find(id);
            context.Banners.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Banner banner)
        {
            context.Banners.Add(banner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var values = context.Banners.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            var values = context.Banners.Find(banner.BannerId);
            values.Title = banner.Title;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
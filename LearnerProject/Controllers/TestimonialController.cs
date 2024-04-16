using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class TestimonialController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Testimonial
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var values = context.Testimonials.Find(testimonial.TestimonialId);
            values.Title = testimonial.Title;
            values.Comment = testimonial.Comment;
            values.ImageUrl = testimonial.ImageUrl;
            values.NameSurname = testimonial.NameSurname;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
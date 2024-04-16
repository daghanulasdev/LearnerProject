using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Course
        public ActionResult Index()
        {
            var values = context.Courses.ToList();
            return View(values);
        }
        public ActionResult DeleteCourse(int id)
        {
            var values = context.Courses.Find(id);
            context.Courses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x=>x.Status==true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text=x.CategoryName,
                                                 Value=x.CategoryId.ToString(),
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString(),
                                             }).ToList();
            ViewBag.category = category;
            var values = context.Courses.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var values = context.Courses.Find(course.CourseId);
            values.CourseName = course.CourseName;
            values.CategoryId = course.CategoryId;
            values.ImageUrl = course.ImageUrl;
            values.Description = course.Description;
            values.Price = course.Price;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
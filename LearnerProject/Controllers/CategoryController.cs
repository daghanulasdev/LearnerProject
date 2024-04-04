using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CategoryController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Category
        public ActionResult Index()
        {
            var values = context.Categories.Where(x => x.Status == true).ToList();
            return View(values);
        }
        public ActionResult DeleteCategory(int id)
        {
            var values = context.Categories.Find(id);
            values.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            category.Status = true;
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values =context.Categories.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var values = context.Categories.Find(category.CategoryId);
            values.CategoryName = category.CategoryName;
            values.Icon = category.Icon;
            values.Status=true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
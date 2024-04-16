using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class ClassroomController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Classroom
        public ActionResult Index()
        {
            var values = context.Classrooms.ToList();
            return View(values);
        }

        public ActionResult DeleteClassroom(int id)
        {
            var values = context.Classrooms.Find(id);
            context.Classrooms.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddClassroom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClassroom(Classroom classroom)
        {
            context.Classrooms.Add(classroom);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateClassroom(int id)
        {
            var values = context.Classrooms.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateClassroom(Classroom classroom)
        {
            var values = context.Classrooms.Find(classroom.ClassroomId);
            values.Description = classroom.Description;
            values.Name = classroom.Name;
            values.Icon = classroom.Icon;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
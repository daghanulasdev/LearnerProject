using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class TeacherLoginController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: TeacherLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            var values = context.Teachers.FirstOrDefault(x=>x.UserName == teacher.UserName&& x.Password==teacher.Password);
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanici adi ve ya sifre hatali");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.UserName,false);
                Session["teacherName"]=values.NameSurname;
                return RedirectToAction("Index","TeacherCourse");
            }
        }
    }
}
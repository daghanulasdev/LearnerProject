﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminLayoutSidebar()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutNavbar()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutScript()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }
    }
}
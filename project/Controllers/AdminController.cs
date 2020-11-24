using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            //di chuyen den area Admin/Home
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISS.Controllers
{
    public class OfficerController : Controller
    {
        // GET: Officer
        public ActionResult addOfficer()
        {
            return View();
        }
        public ActionResult searchOfficer()
        {
            return View();
        }
    }
}
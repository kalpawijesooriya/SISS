using SISS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult myCrimes(string userid)
        {
            using (SISS_Context db = new SISS_Context())
            {
                try
                {
                    string query = "SELECT * FROM Crimes as c INNER JOIN Investigations i on c.CrimeId=i.CrimeId INNER JOIN CrimeOfficers co on c.CrimeId=co.CrimeId INNER JOIN CrimeImages ci on c.CrimeId=ci.CrimeId INNER JOIN Witnesses w on i.InvestigationId=w.InvestigationId INNER JOIN CrimeSuspects cs on i.InvestigationId=cs.InvestigationId INNER JOIN LocationImages li on li.InvestigationId=i.InvestigationId WHERE co.UserEmployeeNumber="+ userid + "";
                    var searchData = db.Database.SqlQuery<Temp.tempClass4>(query).ToList();
                    return Json(searchData);
                }
                catch (Exception e)
                {
                    return Json(e.ToString(), JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}
using SISS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISS.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult reportMain()
        {
            return View();
        }

        public ActionResult findCrimeDetailsforReports(string fromDate, string toDate)
        {
            string rep1 = fromDate;
            string rep2 = toDate;

            using (SISS_Context db = new SISS_Context())
            {
                try
                {
                    string query = "SELECT Crimes.CrimeId, Crimes.CrimeName, Crimes.policeStation, Crimes.crimeLocation, Crimes.ComplaineDate, Investigations.InvestigationStatus FROM Crimes INNER JOIN Investigations ON Crimes.crimeID=Investigations.crimeID WHERE InvestigationStartDate BETWEEN'" + rep1 + "'AND'"+ rep2 + "'";
                    var searchData = db.Database.SqlQuery<Temp.tempClass5>(query).ToList();
                    return Json(searchData);

                }
                catch (Exception e)
                {
                    return Json(e);
                }
            }

        }
    }
}
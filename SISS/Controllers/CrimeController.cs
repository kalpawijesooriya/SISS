using Newtonsoft.Json.Linq;
using SISS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISS.Controllers
{
    public class CrimeController : Controller
    {
     private static  int CrimeID = 0;
        private static int InvestigationId = 0;
        // GET: Complain
        public ActionResult AddCrimeRecord()
        {
            SISS_Context db = new SISS_Context();
            List<User> userList =db.User.ToList();
            ViewBag.userList = userList;
            return View();
        }
        public ActionResult EditCrimeRepot()
        {
            SISS_Context db = new SISS_Context();
            List<User> userList = db.User.ToList();
            List<Crime> crimeList = db.Crime.ToList();
            ViewBag.userList = userList;
            ViewBag.crimeList = crimeList;
            return View();
        }
        [HttpPost]
 
        public ActionResult saveData(string Courtobj, string SpecialDataobj, string SuspectDataobj, string Investigationobj, string OfficerDataobj, string Complaneobj, string Witnessobj)
        {
            JArray CourtList = JArray.Parse(Courtobj) as JArray;
            JArray SpecialList = JArray.Parse(SpecialDataobj) as JArray;
            JArray SuspectList = JArray.Parse(SuspectDataobj) as JArray;
            JArray InvestigationList = JArray.Parse(Investigationobj) as JArray;
            JArray WitnessList = JArray.Parse(Witnessobj) as JArray;
            JArray OfficerList = JArray.Parse(OfficerDataobj) as JArray;
            JArray ComplaneList = JArray.Parse(Complaneobj) as JArray;
           

           
            using (SISS_Context db = new SISS_Context())
            {
                try
                {
                    foreach (JObject item in ComplaneList)
                    {
                    
                        string query1 = "INSERT INTO Crimes ([ComplaineDate],[ComplaineTime],[ComplainantName],[ComplainAddress],[ComplainContactNo],[ComplainTitle],[Statment],[policeStation],[CrimeName],[CrimeLocation],[CrimeType]) VALUES('" + item["ComplaneDate"] + "','" + item["ComplaneTime"] + "','" + item["ComplaniantName"] + "','" + item["ComplaniantAddress"] + "','" + item["ComplaniantContact"] + "','"+ item["ComplaniantTitle"] + "','" + item["Statement"] + "','" + item["station"] + "','"+ item["ComplaneName"] + "','" + item["location"] + "','" + item["crimeType"] + "') SELECT SCOPE_IDENTITY() AS [CrimeId]";

                        var query1Data = db.Database.SqlQuery<Temp.tempClass2>(query1).ToList();
                        CrimeID = Int32.Parse(query1Data[0].CrimeId.ToString());
                    }
                    foreach (JObject item in InvestigationList)
                    {

                        string query2 = "INSERT INTO Investigations ([InvestigationStartDate],[CrimeLocationInvestigationDetails],[CrimeId],[InvestigationStatus]) VALUES('" + item["startDate"] + "','" + item["locationDetails"] +"',"+ CrimeID + ",'PENDING') SELECT SCOPE_IDENTITY() AS [InvestigationId]";

                        var query1Data = db.Database.SqlQuery<Temp.tempClass3>(query2).ToList();
                        InvestigationId = Int32.Parse(query1Data[0].InvestigationId.ToString());
                    }
                    foreach (JObject item in SuspectList)
                    {
                

                        string query3 = "INSERT INTO CrimeSuspects ([FullName],[Address],[NIC],[ContactNumber],[SuspectStatus],[InvestigationId]) VALUES('" + item["SuspectName"] + "','" + item["Address"] + "','" + item["NIC"] + "','" + item["Contact"] + "','" + item["Status"] + "'," + InvestigationId + ")";
                        db.Database.ExecuteSqlCommand(query3);
                    }
                    foreach (JObject item in SpecialList)
                    {
                   
                        string query4 = "INSERT INTO SpecialReports ([ReportType],[SpecialistName],[Designation],[Discription],[InvestigationId]) VALUES('" + item["ReportType"] + "','" + item["SpecialistName"] + "','" + item["Designation"] + "','" + item["Discription"] + "'," + InvestigationId + ")";
                        db.Database.ExecuteSqlCommand(query4);
                    }
                    foreach (JObject item in WitnessList)
                    {

                        string query5 = "INSERT INTO Witnesses ([WitnessName],[WitnessAddress],[WitnessNIC],[WitnessTelephone],[WitnessDiscription],[InvestigationId]) VALUES('" + item["FullName"] + "','" + item["Address"] + "','" + item["NIC"] + "','" + item["ContactNumber"] + "','" + item["Discription"] + "'," + InvestigationId + ")";
                        db.Database.ExecuteSqlCommand(query5);
                    }
                    foreach (JObject item in OfficerList)
                    {
                        string query6 = "INSERT INTO CrimeOfficers ([UserEmployeeNumber],[CrimeId],[oder]) VALUES('" + item["Officername"] + "'," + CrimeID + "," + 0 + ")";
                        db.Database.ExecuteSqlCommand(query6);
                    }
                    foreach (JObject item in CourtList)
                    {
                        
                        string query7 = "INSERT INTO InvestigationResults ([CourtDecision],[Punishment],[Note],[InvestigationId]) VALUES('" + item["CourtDecision"] + "','" + item["Punishment"] + "','" + item["Note"] + "'," + InvestigationId + ")";
                        db.Database.ExecuteSqlCommand(query7);
                    }


                   
                }
                catch (Exception e)
                {
                    return Json(e.ToString(), JsonRequestBehavior.AllowGet);
                   
                }
            }

            return Json("done!", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
           
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images/Suspects/"), fileName);
                file.SaveAs(path);

                var dbPath = "../Content/Images/Suspects/" + fileName;

                using (SISS_Context db = new SISS_Context())
                {
                    try
                    {
                        string query = "INSERT INTO CrimeImages ([imagePath],[CrimeId]) VALUES('" + dbPath + "'," + CrimeID + ")";
                        db.Database.ExecuteSqlCommand(query);
                    }
                    catch (Exception e)
                    {
                        return Json(e.ToString(), JsonRequestBehavior.AllowGet);
                    }
                }
            }

            return Json("Successfully Data Added", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadLocationFiles()
        {

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Images/Suspects/"), fileName);
                file.SaveAs(path);

                var dbPath = "../Content/Images/Locations/" + fileName;

                using (SISS_Context db = new SISS_Context())
                {
                    try
                    {
                        string query = "INSERT INTO LocationImages ([LocationimagePath],[InvestigationId]) VALUES('" + dbPath + "'," + InvestigationId + ")";
                        db.Database.ExecuteSqlCommand(query);
                    }
                    catch (Exception e)
                    {
                        return Json(e.ToString(), JsonRequestBehavior.AllowGet);
                    }
                }
            }

            return Json("Successfully Data Added", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult findCrime(string Key)
        {
            using (SISS_Context db = new SISS_Context())
            {
                int x = Int32.Parse(Key);
                try
                {
                    string query = "SELECT * FROM Crimes as c INNER JOIN Investigations i on c.CrimeId=i.CrimeId INNER JOIN CrimeOfficers co on c.CrimeId=co.CrimeId INNER JOIN CrimeImages ci on c.CrimeId=ci.CrimeId INNER JOIN Witnesses w on i.InvestigationId=w.InvestigationId INNER JOIN CrimeSuspects cs on i.InvestigationId=cs.InvestigationId INNER JOIN LocationImages li on li.InvestigationId=i.InvestigationId INNER JOIN SpecialReports sr on i.InvestigationId=sr.InvestigationId INNER JOIN InvestigationResults ir on i.InvestigationId=ir.InvestigationId WHERE co.CrimeId=" + x;
                    var CrimeData = db.Database.SqlQuery<Temp.tempClass4>(query).ToList();

                  



                    return Json(CrimeData);

                }
                catch (Exception e)
                {
                    return Json(e);
                }

            }
        }

    }
}
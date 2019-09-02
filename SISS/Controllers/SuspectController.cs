using Newtonsoft.Json.Linq;
using SISS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISS.Controllers
{
    
    public class SuspectController : Controller
    {
        public static int NewSuspectID = 0;
        // GET: Suspect
        public ActionResult AddSuspect()
        {
            return View();
        }
        public ActionResult SearchSuspect()
        {
            return View();
        }

 
        [HttpPost]
        public ActionResult saveList(string relation, string Suspects)
        {
            JArray relationList = JArray.Parse(relation) as JArray;
            JArray SuspectsList = JArray.Parse(Suspects) as JArray;
            using (SISS_Context db = new SISS_Context())

            {
                try {

                    foreach (JObject item in SuspectsList)
                    {

                        string query1 = "INSERT INTO Suspects ([FullName],[NameWithInitials],[NickName],[Address],[CurrentCity],[ContactNumber],[NIC],[BirthDay],[AddBy]) VALUES('" + item["FullName"] + "','" + item["Initials"] + "','" + item["Nick"] + "','" + item["Address"] + "','" + item["NICNum"] + "'," +Int32.Parse(item["Telephone"].ToString() )+ ",'" + item["CurrentCity"] + "','" + item["BirthDay"] + "','" + Session["userID"] + "') SELECT SCOPE_IDENTITY() AS [SuspectID]";

                        var chart1Data = db.Database.SqlQuery<Temp.tempClass1>(query1).ToList();
                        NewSuspectID = Int32.Parse(chart1Data[0].SuspectID.ToString());
                    }

                    foreach (JObject item in relationList)
                    {
                        string query = "INSERT INTO Relations ([FullName],[RelationShip],[Addres],[NIC],[ContactNumber],[Discription],[SuspectID]) VALUES('" + item["name"] + "','" + item["relation"] + "','" + item["address"] + "','" + item["nic"] + "','" + item["contact"] + "','" + item["discription"] + "'," + NewSuspectID + ") ";
                        db.Database.ExecuteSqlCommand(query);
                    }

                }
                catch (Exception e) {
                    return this.Json(e, JsonRequestBehavior.AllowGet);

                }
                
                    
              

            }
            return Json("List Saved!", JsonRequestBehavior.AllowGet);
        }


        public ActionResult findsuspect(String KeyWord)
        {
            using (SISS_Context db = new SISS_Context())
            {
                string x = KeyWord.Replace("\"", "");
                try
                {
                    string query = "SELECT * FROM Suspects WHERE CONCAT(FullName,NickName,Address,AddBy,CurrentCity,BirthDay,NIC,ContactNumber,NameWithInitials) LIKE '%" + x + "%' ORDER BY FullName ASC";
                    var searchData = db.Database.SqlQuery<Suspect>(query).ToList();

                    return Json(searchData);

                }
                catch (Exception e)
                {
                    return Json(e);
                }

            }
        }

         [HttpPost]
        public ActionResult findsuspectRecord(int suspectId)
        {
           

            using (SISS_Context db = new SISS_Context())
            {

                try
                {
                    string query = "SELECT * FROM Suspects WHERE SuspectID=" + suspectId ;
                    var searchData = db.Database.SqlQuery<Suspect>(query).ToList();
                    return Json(searchData);

                }
                catch (Exception e)
                {
                    return Json(e);
                }
            }

        }

        [HttpPost]
        public ActionResult updateSuspect(string suspect)
        {
            JArray suspectList = JArray.Parse(suspect) as JArray;
            using (SISS_Context db = new SISS_Context())
            {
                try
                {


                    foreach (JObject item in suspectList)
                    {
                        string query = "UPDATE Suspects SET FullName = '" + item["FullName"] + "', NickName = '" + item["nic"] + "', BirthDay = '" + item["dob"] + "',Address = '" + item["address"] + "',CurrentCity = '" + item["city"] + "',NameWithInitials = '" + item["initial"] + "',NIC = '" + item["nicNum"] + "',ContactNumber = '" + Int32.Parse(item["telephone"].ToString()) + "' WHERE SuspectID='" + item["id"] + "'";
                        db.Database.ExecuteSqlCommand(query);

                    }
                }
                catch (Exception e)
                {
                    return this.Json(e, JsonRequestBehavior.AllowGet);

                }
            }
            return Json("Suspect Data Updated!", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult deleteSuspect(int suspectId)
        {
            using (SISS_Context db = new SISS_Context())
            {
                try
                {



                    string query = "DELETE FROM Suspects WHERE SuspectID=" + suspectId;
                    db.Database.ExecuteSqlCommand(query);


                }
                catch (Exception e)
                {
                    return this.Json(e, JsonRequestBehavior.AllowGet);

                }
            }
            return Json("Suspect Data Deleted!", JsonRequestBehavior.AllowGet);
        }


    }
}
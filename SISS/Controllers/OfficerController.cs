using Newtonsoft.Json.Linq;
using SISS.Models;
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



        [HttpPost]
        public ActionResult AddUser(User user)
        {

            try
            {
                string role = null;
                if (user.officerDesignation == "DIG")
                {
                    role = "Administrator";
                }
                else if (user.officerDesignation == "OIC")
                {
                    role = "Senior Officer";
                }
                else  { role = "Normal Officer"; }

                using (SISS_Context db = new SISS_Context())
                {
                    
                    string query = "INSERT INTO Users ([officerName],[officerFullName],[officerGender],[officerBirthday],[officerDesignation],[officerJoindDate],[officerNIC],[officerPoliceStation],[officerTelephone],[officerMarrageStatus],[UserEmployeeNumber]) VALUES('" + user.officerName + "','" + user.officerFullName + "','" + user.officerGender + "','" + user.officerBirthday + "','" + user.officerDesignation + "','" + user.officerJoindDate + "','" + user.officerNIC + "','" + user.officerPoliceStation + "','" + user.officerTelephone + "','" + user.officerMarrageStatus + "','" + user.UserEmployeeNumber + "') ";
                    string query2 = "INSERT INTO Logins([password], [userName], [Role], [UserEmployeeNumber]) VALUES('" + user.UserEmployeeNumber + "','"+ user.UserEmployeeNumber + "','" + role + "','" + user.UserEmployeeNumber + "') "; ;
                    db.Database.ExecuteSqlCommand(query);
                    db.Database.ExecuteSqlCommand(query2);
                }
                user.UserSuccessMessage = "Sucesfully Saved";//show login erroe message
                return RedirectToAction("addOfficer", "Officer");
             

            }
            catch (Exception e)
            {
                user.UserErrorMessage = e.ToString();//show login erroe message
               
                return RedirectToAction("addOfficer", "Officer");
            }
        }
        [HttpPost]
        public ActionResult findOfficer(String KeyWord)
        {
            using (SISS_Context db = new SISS_Context())
            {
                string x = KeyWord.Replace("\"", "");
                try {
                    string query = "SELECT * FROM Users WHERE CONCAT(officerFullName,officerBirthday,officerDesignation,officerJoindDate,officerGender,officerMarrageStatus,officerPoliceStation,officerName,officerNIC,UserEmployeeNumber) LIKE '%"+ x + "%' ORDER BY officerFullName ASC";
                    var searchData = db.Database.SqlQuery<User>(query).ToList();
                   
                    return Json(searchData);

                }
                catch (Exception e)
                {
                    return Json(e);
                }
                  
            }
        }

        [HttpPost]
        public ActionResult findUser(string userid)
        {
            String str2 = userid.Replace("\"", "");

            using (SISS_Context db = new SISS_Context())
            {
                
                try
                {
                    string query = "SELECT * FROM Users WHERE UserEmployeeNumber='"+ str2 + "'" ;
                    var searchData = db.Database.SqlQuery<User>(query).ToList();
                    return Json(searchData);

                }
                catch (Exception e)
                {
                    return Json(e);
                }
            }

        }
        [HttpPost]
        public ActionResult updateUser(string user)
        {
            JArray userList = JArray.Parse(user) as JArray;
            using (SISS_Context db = new SISS_Context())
            {
                try
                {
         

                    foreach (JObject item in userList)
                    {
                        string query = "UPDATE Users SET officerFullName = '"+ item["FullName"] + "', officerName = '"+ item["name"] + "', officerBirthday = '"+ item["dob"] + "',officerDesignation = '"+ item["designation"] + "',officerGender = '"+ item["gender"] + "',officerJoindDate = '"+ item["joindDate"] + "',officerMarrageStatus = '"+ item["marageStatus"] + "',officerPoliceStation = '"+ item["station"] + "',officerNIC = '"+ item["nic"] + "',officerTelephone = '"+ Int32.Parse(item["telephone"].ToString()) + "' WHERE UserEmployeeNumber='"+ item["id"] + "'";
                        db.Database.ExecuteSqlCommand(query);
                        
                    }
                }
                catch (Exception e)
                {
                    return this.Json(e, JsonRequestBehavior.AllowGet);

                }
            }
            return Json("User Data Updated!", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult deleteUser(int userId)
        {
            using (SISS_Context db = new SISS_Context())
            {
                try
                {


                   
                        string query = "DELETE FROM Users WHERE UserEmployeeNumber='" + userId + "'";
                        db.Database.ExecuteSqlCommand(query);

                    
                }
                catch (Exception e)
                {
                    return this.Json(e, JsonRequestBehavior.AllowGet);

                }
            }
            return Json("User Data Deleted!", JsonRequestBehavior.AllowGet);
        }
    }
}
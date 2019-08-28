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
    }
}
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
        public ActionResult AddSuspect(Suspect suspect)
        {

            try
            {
                

                using (SISS_Context db = new SISS_Context())
                {

                    string query = "INSERT INTO Suspects ([FullName],[NameWithInitials],[NickName],[Address],[CurrentCity],[BirthDay],[NIC],[ContactNumber],[AddBy]) VALUES('" + suspect.FullName + "','" + suspect.NameWithInitials + "','" + suspect.NickName + "','" + suspect.Address + "','" + suspect.CurrentCity + "','" + suspect.BirthDay + "','" + suspect.NIC + "','" + suspect.ContactNumber + "','"+ Session["userID"] + "') ";
                   // string query2 = "INSERT INTO Logins([password], [userName], [Role], [UserEmployeeNumber]) VALUES('" + user.UserEmployeeNumber + "','" + user.UserEmployeeNumber + "','" + role + "','" + user.UserEmployeeNumber + "') "; ;
                    db.Database.ExecuteSqlCommand(query);
                    //db.Database.ExecuteSqlCommand(query2);
                }
                suspect.SuspectSuccessMessage = "Sucesfully Saved";//show login erroe message
                return RedirectToAction("addSuspect", "Suspect");


            }
            catch (Exception e)
            {
                suspect.SuspectErrorMessage = e.ToString();//show login erroe message

                return RedirectToAction("addSuspect", "Suspect");
            }
        }


        [HttpPost]
        public ActionResult saveList(string relation)
        {
            JArray relationList = JArray.Parse(relation) as JArray;
            foreach (JObject item  in relationList)
            {
               string name= item["nic"].ToString();
               


            }
            return Json("List Saved!", JsonRequestBehavior.AllowGet);
        }

   }
}